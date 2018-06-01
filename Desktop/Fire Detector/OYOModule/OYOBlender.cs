using OpenCvSharp;
using System;

namespace oyo
{
    //
    // Lx8Blender
    //  블렌딩 작업을 하는 클래스입니다.
    //  백그라운드 이미지(실화상 이미지)와 포그라운드 이미지(적외선 이미지) 그리고
    //  포그라운드의 관심영역을 추출하기 위한 마스크 총 3가지의 정보가 업데이트되면
    //  블렌딩 작업을 수행할 수 있습니다.
    //
    public partial class OYOBlender
	{
        //
        // _foreground
        //  적외선 이미지로 쓰일 이미지입니다.
        //  일정 부분을 제거하여 블렌딩합니다.
        //
		private Mat				 _foreground;

        //
        // _background
        //  실화상 이미지로 쓰일 이미지입니다.
        //  어느 영억을 제거하지 않으며 포그라운드의 관심영역과 블렌딩됩니다.
        //
		private Mat				 _background;

        //
        // Mask
        //  _foreground의 관심영역을 추출하기 위한 마스크입니다.
        //
		private Mat				 _mask;
        public Mat Mask
        {
            get
            {
                return this._mask;
            }
        }

        //
        // Size
        //  블렌딩의 결과로 얻을 이미지의 크기입니다.
        //  두 이미지의 해상도가 다를 수 있기 때문에 사용자는 블렌딩된 결과 이미지의 크기를
        //  미리 지정해두어야 합니다.
        //
		public Size Size { get; set; }

        //
        // Smooth
        //  포그라운드의 관심영역을 추출해낸 뒤 블러처리를 할 지의 여부입니다.
        //  이 값이 false라면 더 빠른 속도를 내지만 잘라내어진 영역이 부자연스럽고 날카롭습니다.
        //  true라면 자연스럽게 보이지만 속도가 느립니다.
        //
		public bool Smooth { get; set; }

        //
        // Transparency
        //  0.0 ~ 1.0 사이의 값을 가지는 포그라운드의 투명도입니다.
        //  이 값이 0이라면 완전한 불투명으로써 관심영역의 백그라운드가 보이지 않습니다.
        //  반대로 1인 경우 완전 투명으로써 포그라운드가 보이지 않습니다.
        //
		private float _transparency;
		public float Transparency
		{
			get
			{
				return this._transparency;
			}
			set
			{
				this._transparency = Math.Max(0.0f, Math.Min(1.0f, value));
			}
		}

        //public Rect InfraredCroppedRect { get; set; }


        //
        // Blendable
        //  블렌딩 작업을 수행할 수 있는지의 여부입니다.
        //  요구하는 3가지의 값(마스크, 백그라운드, 포그라운드)가 모두 업데이트 되어 있어야 합니다.
        //
		public bool Blendable
		{
			get
			{
				return this._mask != null && this._background != null && this._foreground != null;
			}
		}

		public OYOBlender(Size size, float alpha = 0.5f, bool smooth = true)
		{
			this.Size				    = size;
			this.Smooth				    = smooth;
			this.Transparency		    = alpha;
		}

        //
        // Blending
        //  블렌딩 작업을 수행합니다.
        //
        // Return
        //  성공시 블렌딩된 이미지, 실패시 null
        //
		public Mat Blending()
		{
			if (this.Blendable == false)
				return null;

			var mask				= this.Smooth ? this._mask.GaussianBlur(new Size(21, 21), 11.0) : this._mask;
			var mask_inv			= (~mask).ToMat();

            var mask_norm           = new Mat();
            var mask_inv_norm       = new Mat();
			if (mask.CountNonZero() == 0)
            {
                mask_inv_norm       = new Mat(mask.Size(), MatType.CV_32FC1, new Scalar(1.0));
                mask_norm           = new Mat(mask.Size(), MatType.CV_32FC1, new Scalar(0.0));
            }
            else if (mask_inv.CountNonZero() == 0)
            {
                mask_norm           = new Mat(mask.Size(), MatType.CV_32FC1, new Scalar(1.0));
                mask_inv_norm       = new Mat(mask.Size(), MatType.CV_32FC1, new Scalar(0.0));
            }
            else
            {
                mask_norm           = mask.Normalize(0, 1, NormTypes.MinMax, MatType.CV_32FC1);
                mask_inv_norm       = mask_inv.Normalize(0, 1, NormTypes.MinMax, MatType.CV_32FC1);
            }

            mask_norm = mask_norm.CvtColor(ColorConversionCodes.GRAY2BGR);
            mask_inv_norm = mask_inv_norm.CvtColor(ColorConversionCodes.GRAY2BGR);

			var background32f	    = new Mat();
			this._background.ConvertTo(background32f, MatType.CV_32FC3);

			var foreground32f       = new Mat();
			this._foreground.ConvertTo(foreground32f, MatType.CV_32FC3);

            var blended_frame       = new Mat();
            Cv2.AddWeighted(foreground32f.Mul(mask_norm), 1.0f - this.Transparency, background32f.Mul(mask_norm), this.Transparency, 0, blended_frame);

            blended_frame += background32f.Mul(mask_inv_norm);
            blended_frame.ConvertTo(blended_frame, MatType.CV_8UC3);

            return blended_frame;
        }

        //
        // Update
        //  포그라운드와 마스크를 업데이트합니다.
        //
        // Parameters
        //  foreground              포그라운드 이미지
        //  mask                    포그라운드의 관심영역 마스크
        //
        // Return
        //  이번 업데이트로 블렌딩이 가능한지의 여부를 리턴
        //
		public bool Update(Mat foreground, Mat mask)
		{
			this._foreground        = foreground;
			if(this._foreground.Size() != this.Size)
				this._foreground    = this._foreground.Resize(this.Size);

			if (this._foreground.Channels() == 1)
				this._foreground.CvtColor(ColorConversionCodes.GRAY2BGR);
    
			this._mask              = mask;
			if (this._mask.Type() != MatType.CV_8UC1)
				this._mask.ConvertTo(this._mask, MatType.CV_8UC1);
			if(this._mask.Size() != this.Size)
				this._mask          = this._mask.Resize(this.Size);

            //this._foreground        = this._foreground.Clone(this.InfraredCroppedRect).Resize(this.Size);
            //this._mask              = this.Mask.Clone(this.InfraredCroppedRect).Resize(this.Size);

			return this.Blendable;
		}

        //
        // Update
        //  백그라운드를 업데이트합니다.
        //
        // Parameters
        //  background              백그라운드 이미지
        //
        // Return
        //  이번 업데이트로 블렌딩이 가능한지의 여부를 리턴
        //
		public bool Update(Mat background)
		{
			this._background        = background;
			if(this._background.Size() != this.Size)
				this._background    = this._background.Resize(this.Size);

			if (this._background.Channels() == 1)
				this._background    = this._background.CvtColor(ColorConversionCodes.GRAY2BGR);

			//this._background        = this._background.Clone(this.VisualCroppedRect).Resize(this.Size);

			return this.Blendable;
		}
	}
}
