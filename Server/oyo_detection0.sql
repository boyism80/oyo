-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: cshyeon.dlinkddns.com    Database: oyo
-- ------------------------------------------------------
-- Server version	5.1.41-community

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `detection`
--

DROP TABLE IF EXISTS `detection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detection` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `addr` char(16) COLLATE utf8_unicode_ci NOT NULL,
  `lat` decimal(10,8) NOT NULL,
  `lon` decimal(11,8) NOT NULL,
  `temperature` decimal(5,2) NOT NULL,
  `thumb` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `infrared` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `visual` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `date` datetime NOT NULL,
  `deleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=59 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detection`
--

LOCK TABLES `detection` WRITE;
/*!40000 ALTER TABLE `detection` DISABLE KEYS */;
INSERT INTO `detection` VALUES (58,'127.0.0.1',37.56647000,126.97796300,72.65,'static/images/thumb_524154dd-f7f9-4752-86de-a98e650bf094.jpg','static/images/inf_81291f97-ac3d-4f1f-81ef-56e5affa9a3f.jpg','static/images/vis_5443ef2e-3057-4e9b-a4e5-5dbc9990194f.jpg','2018-05-28 19:42:44',0),(57,'127.0.0.1',37.56647000,126.97796300,72.65,'static/images/thumb_fbeda8f9-9661-44c1-9da7-08c9e22e9188.jpg','static/images/inf_3eab941b-4984-4367-8601-de7d96afafb4.jpg','static/images/vis_8c398025-60a7-4d57-947e-d71a012a9f85.jpg','2018-05-28 19:42:08',0);
/*!40000 ALTER TABLE `detection` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-04 17:37:18
