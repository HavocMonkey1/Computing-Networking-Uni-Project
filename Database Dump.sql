-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: note_taking_database
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(15) NOT NULL,
  `Read` tinyint NOT NULL,
  `Write` tinyint NOT NULL,
  `Delete` tinyint NOT NULL,
  `Create` tinyint NOT NULL,
  `Admin` tinyint NOT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sessions`
--

DROP TABLE IF EXISTS `sessions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sessions` (
  `SessionID` int NOT NULL AUTO_INCREMENT,
  `Token` varchar(50) NOT NULL,
  `UserID` int NOT NULL,
  `Timeout` timestamp NOT NULL,
  PRIMARY KEY (`SessionID`),
  UNIQUE KEY `SessionID_UNIQUE` (`SessionID`),
  UNIQUE KEY `Token_UNIQUE` (`Token`)
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sessions`
--

LOCK TABLES `sessions` WRITE;
/*!40000 ALTER TABLE `sessions` DISABLE KEYS */;
INSERT INTO `sessions` VALUES (2,'55736572315ebb03a9',1,'2020-05-13 00:14:37'),(3,'55736572315ebb041a',1,'2020-05-13 00:16:37'),(4,'55736572315ebb05a9',1,'2020-05-13 00:23:13'),(5,'55736572315ebc0ed2',1,'2020-05-13 19:14:26'),(6,'55736572315ebc107a',1,'2020-05-13 19:21:30'),(7,'55736572315ebc1825',1,'2020-05-13 19:54:13'),(8,'55736572315ebd3141',1,'2020-05-14 15:53:37'),(9,'55736572315ebd56b0',1,'2020-05-14 18:33:20'),(10,'55736572315ebd56d7',1,'2020-05-14 18:33:59'),(11,'55736572315ebd9efd',1,'2020-05-14 23:41:49'),(12,'55736572315ebd9fc6',1,'2020-05-14 23:45:10'),(13,'55736572315ebda000',1,'2020-05-14 23:46:08'),(14,'55736572315ebda161',1,'2020-05-14 23:52:01'),(15,'55736572315ebda408',1,'2020-05-15 00:03:20'),(16,'55736572315ebdbae9',1,'2020-05-15 01:40:57'),(17,'55736572315ebdbd7f',1,'2020-05-15 01:51:59'),(18,'55736572315ebdc7c3',1,'2020-05-15 02:35:47'),(19,'55736572315ebdc8c3',1,'2020-05-15 02:40:03'),(20,'55736572315ebdc984',1,'2020-05-15 02:43:16'),(21,'55736572315ebdcae4',1,'2020-05-15 02:49:08'),(22,'55736572315ebdcde7',1,'2020-05-15 03:01:59'),(23,'55736572315ebdcee5',1,'2020-05-15 03:06:13'),(24,'55736572315ebdcf12',1,'2020-05-15 03:06:58'),(25,'55736572315ebdd0b3',1,'2020-05-15 03:13:55'),(26,'55736572315ebe56b7',1,'2020-05-15 12:45:43'),(27,'55736572315ebe56b8',1,'2020-05-15 12:45:44'),(28,'55736572315ebe5760',1,'2020-05-15 12:48:32'),(29,'55736572315ebe57be',1,'2020-05-15 12:50:06'),(30,'55736572315ebe5854',1,'2020-05-15 12:52:36'),(31,'55736572315ebe5a5b',1,'2020-05-15 13:01:15'),(32,'55736572315ebe5aa9',1,'2020-05-15 13:02:33'),(33,'55736572315ebe5b78',1,'2020-05-15 13:06:00'),(34,'55736572315ebe5b9f',1,'2020-05-15 13:06:39'),(35,'55736572315ebe5c28',1,'2020-05-15 13:08:56'),(36,'55736572315ebe5c5e',1,'2020-05-15 13:09:50'),(37,'55736572315ebe5d33',1,'2020-05-15 13:13:23'),(38,'55736572315ebe5da6',1,'2020-05-15 13:15:18'),(39,'55736572315ebe5df4',1,'2020-05-15 13:16:36'),(40,'55736572315ebe5e80',1,'2020-05-15 13:18:56'),(41,'55736572315ebe5ee0',1,'2020-05-15 13:20:32'),(42,'55736572315ebe5f83',1,'2020-05-15 13:23:15'),(43,'55736572315ebe5fd9',1,'2020-05-15 13:24:41'),(44,'55736572315ebe6349',1,'2020-05-15 13:39:21'),(45,'55736572315ebe6729',1,'2020-05-15 13:55:53'),(46,'55736572315ebe67a2',1,'2020-05-15 13:57:54'),(47,'55736572315ebe6912',1,'2020-05-15 14:04:02'),(48,'55736572315ebe6950',1,'2020-05-15 14:05:04'),(49,'55736572315ebe69cd',1,'2020-05-15 14:07:09'),(50,'55736572315ebe6a59',1,'2020-05-15 14:09:29'),(51,'55736572315ebe6ae0',1,'2020-05-15 14:11:44'),(52,'55736572315ebe6b2f',1,'2020-05-15 14:13:03'),(53,'55736572315ebe6c2d',1,'2020-05-15 14:17:17'),(54,'55736572315ebe6cd4',1,'2020-05-15 14:20:04'),(55,'55736572315ebe722f',1,'2020-05-15 14:42:55'),(56,'55736572315ebe74c4',1,'2020-05-15 14:53:56'),(57,'55736572315ebe767a',1,'2020-05-15 15:01:14'),(58,'55736572315ebe770a',1,'2020-05-15 15:03:38'),(59,'55736572315ebe789c',1,'2020-05-15 15:10:20'),(60,'55736572315ebe78d9',1,'2020-05-15 15:11:21'),(61,'55736572315ebe796c',1,'2020-05-15 15:13:48'),(62,'55736572315ebe7a4d',1,'2020-05-15 15:17:33'),(63,'55736572315ebe7a9b',1,'2020-05-15 15:18:51'),(64,'55736572315ebe7b78',1,'2020-05-15 15:22:32'),(65,'55736572315ebe7bdc',1,'2020-05-15 15:24:12'),(66,'55736572315ebe7c5b',1,'2020-05-15 15:26:19'),(67,'55736572315ebe7d43',1,'2020-05-15 15:30:11'),(68,'55736572315ebe7ddb',1,'2020-05-15 15:32:43'),(69,'55736572315ebe7ee0',1,'2020-05-15 15:37:04');
/*!40000 ALTER TABLE `sessions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `text_contents`
--

DROP TABLE IF EXISTS `text_contents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `text_contents` (
  `NoteID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `TextContents` varchar(5500) NOT NULL,
  `HeaderContents` varchar(100) NOT NULL,
  PRIMARY KEY (`NoteID`),
  UNIQUE KEY `MessageID_UNIQUE` (`NoteID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `text_contents`
--

LOCK TABLES `text_contents` WRITE;
/*!40000 ALTER TABLE `text_contents` DISABLE KEYS */;
INSERT INTO `text_contents` VALUES (12,1,'b\r\nTHis is a note three','Note1'),(13,1,'b\r\nTHis is a note too','Note2');
/*!40000 ALTER TABLE `text_contents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(20) NOT NULL,
  `UserPassword` varchar(20) NOT NULL,
  `UserRole` int NOT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `UserName_UNIQUE` (`UserName`),
  UNIQUE KEY `UserID_UNIQUE` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'User1','NotMyPassword123',0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-15 12:40:16
