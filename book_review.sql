-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: bookreviews
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `author`
--

DROP TABLE IF EXISTS `author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `author` (
  `author_id` char(36) NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `description` text,
  `date_of_birth` date NOT NULL,
  `nationality` varchar(100) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`author_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `author`
--

LOCK TABLES `author` WRITE;
/*!40000 ALTER TABLE `author` DISABLE KEYS */;
/*!40000 ALTER TABLE `author` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book` (
  `book_id` char(36) NOT NULL,
  `book_name` varchar(255) NOT NULL,
  `author_name` varchar(255) DEFAULT NULL,
  `author_id` char(36) DEFAULT NULL,
  `genre` varchar(100) DEFAULT NULL,
  `isbn` varchar(20) DEFAULT NULL,
  `publication_date` date DEFAULT NULL,
  `description` text,
  `avg_rate` float DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  `user_id` char(36) NOT NULL,
  `book_review` text,
  `status` int DEFAULT '1',
  PRIMARY KEY (`book_id`),
  UNIQUE KEY `isbn` (`isbn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES ('665486b8-047a-4860-b34a-5ed9f7b0a585','The Fund: Ray Dalio, Bridgewater Associates, and the Unraveling of a Wall Street Legend','','00000000-0000-0000-0000-000000000000','','T02','2024-09-07','<p>The unauthorized, unvarnished story of famed Wall Street hedge-fund manager Ray Dalio.<br><br>Ray Dalio does not want you to read this book.<br><br>Late last year, when the billionaire founder of Bridgewater Associates, the largest hedge fund on the planet, announced that he was stepping down from the company he started out of his apartment nearly 50 years ago, the news made headlines around the world. Dalio cultivated an aura of international admiration and fame thanks to his company&rsquo;s eye-popping success, coupled with a mystique he encouraged with frequent media appearances, celebrity hobnobbing, and his bestselling book, Principles . In The Fund , award-winning New York Times journalist Rob Copeland punctures this carefully-constructed narrative of the benevolent business titan, exposing his much-promoted&nbsp; as one of the great feats of hubris in modern memory―in practice, they encouraged a toxic culture of paranoia and backstabbing.</p>',5,'2024-09-09 21:53:25','','','2024-09-09 21:53:25','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',NULL,2),('87dfb43c-8ca8-4d60-8ba2-baa2cea6da33','The Three-Body Problem','','00000000-0000-0000-0000-000000000000','','T01','2024-09-06','<p>Set against the backdrop of China Cultural Revolution, a secret military project sends signals into space to establish contact with aliens. An alien civilization on the brink of destruction captures the signal and plans to invade Earth. Meanwhile, on Earth, different camps start forming, planning to either welcome the superior beings and help them take over a world seen as corrupt, or to fight against the invasion.</p>\n<div id=\"eJOY__extension_root\" class=\"eJOY__extension_root_class\" style=\"all: unset;\"></div>',3.5,'2024-09-09 21:51:03','','','2024-09-09 21:51:03','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',NULL,1),('de53b690-a83b-4594-9168-347dfc89c2aa','Number Go Up: Inside Cryptos Wild Rise and Staggering Fall','','00000000-0000-0000-0000-000000000000','','T03','2024-09-07','<p>In 2021 cryptocurrency went mainstream. Giant investment funds were buying it; celebrities like Tom Brady endorsed it were buying it; celebrities like Tom Brady endorsed it, celebrities like Tom Brady endorsed it</p>',1.3,'2024-09-09 21:54:46','','','2024-09-09 21:54:46','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',NULL,1),('fa0aa418-11d3-4bb1-8488-b61f8c0b4977','Gender Queer',NULL,'00000000-0000-0000-0000-000000000000',NULL,'T04','2024-09-05','<p>In 2014, Maia Kobabe, who uses e/em/eir pronouns, \'thought \'that a comic of reading statistics would be the last autobiographical comic e would ever write. At the time, it was the only thing e felt comfortable with strangers knowing about em. Now, <em>Gender Queer</em>&nbsp;is here. Maia\'s intensely cathartic autobiography charts eir journey of self-identity, which includes the mortification and confusion of adolescent crushes, grappling with how to come out to family and society, bonding with friends over erotic gay fanfiction, and facing the trauma of pap smears. Started as a way to explain to eir family what it means to be nonbinary and asexual,&nbsp;<em>Gender Queer</em> is more than a personal story: it is a useful and touching guide on gender identity&mdash;what it means and how to think about it&mdash;for advocates, friends, and humans everywhere.</p>',4,'2024-09-11 20:23:37',NULL,NULL,'2024-09-11 20:23:37','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',NULL,1);
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `booklist`
--

DROP TABLE IF EXISTS `booklist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `booklist` (
  `book_list_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `list_type` int DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`book_list_id`),
  KEY `booklist_ibfk_1` (`user_id`),
  CONSTRAINT `booklist_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booklist`
--

LOCK TABLES `booklist` WRITE;
/*!40000 ALTER TABLE `booklist` DISABLE KEYS */;
INSERT INTO `booklist` VALUES ('17703b51-e0e1-4449-b0ec-a023963bf55d','2c4cd974-58c4-4b10-a5c7-94c4177dc24f',1,'2024-09-24 23:12:07',NULL,NULL,'2024-09-24 23:12:07'),('2cb2ab8e-9753-49e2-a534-a9018e6312fb','2c4cd974-58c4-4b10-a5c7-94c4177dc24f',2,'2024-09-24 23:12:17',NULL,NULL,'2024-09-24 23:12:17'),('fe4792f6-e074-4ff8-b2fd-03d9b13935ed','2c4cd974-58c4-4b10-a5c7-94c4177dc24f',3,'2024-09-28 01:18:25',NULL,NULL,'2024-09-28 01:18:25');
/*!40000 ALTER TABLE `booklist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `booklistitem`
--

DROP TABLE IF EXISTS `booklistitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `booklistitem` (
  `book_list_item_id` char(36) NOT NULL,
  `book_list_id` char(36) NOT NULL,
  `book_id` char(36) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`book_list_item_id`),
  KEY `booklistitem_ibfk_1` (`book_list_id`),
  KEY `booklistitem_ibfk_2` (`book_id`),
  CONSTRAINT `booklistitem_ibfk_1` FOREIGN KEY (`book_list_id`) REFERENCES `booklist` (`book_list_id`),
  CONSTRAINT `booklistitem_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booklistitem`
--

LOCK TABLES `booklistitem` WRITE;
/*!40000 ALTER TABLE `booklistitem` DISABLE KEYS */;
INSERT INTO `booklistitem` VALUES ('39ce04f3-bb39-4d6b-a7b0-a2e3c7f69880','17703b51-e0e1-4449-b0ec-a023963bf55d','fa0aa418-11d3-4bb1-8488-b61f8c0b4977','2024-09-24 23:12:10',NULL,NULL,'2024-09-24 23:12:10'),('5244b7a9-03b0-4fce-b7f7-6ab54fee4702','17703b51-e0e1-4449-b0ec-a023963bf55d','de53b690-a83b-4594-9168-347dfc89c2aa','2024-09-24 23:12:08',NULL,NULL,'2024-09-24 23:12:08'),('dfc21808-9362-4ce4-a0c9-e35a18bfb518','2cb2ab8e-9753-49e2-a534-a9018e6312fb','87dfb43c-8ca8-4d60-8ba2-baa2cea6da33','2024-09-24 23:12:07',NULL,NULL,'2024-09-24 23:12:07');
/*!40000 ALTER TABLE `booklistitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `club`
--

DROP TABLE IF EXISTS `club`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `club` (
  `club_id` char(36) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `description` text,
  `creator_id` char(36) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`club_id`),
  KEY `creator_id` (`creator_id`),
  CONSTRAINT `club_ibfk_1` FOREIGN KEY (`creator_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `club`
--

LOCK TABLES `club` WRITE;
/*!40000 ALTER TABLE `club` DISABLE KEYS */;
/*!40000 ALTER TABLE `club` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clubmembership`
--

DROP TABLE IF EXISTS `clubmembership`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clubmembership` (
  `club_membership_id` char(36) NOT NULL,
  `club_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `role` enum('Admin','Member') NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`club_membership_id`),
  KEY `clubmembership_ibfk_1` (`club_id`),
  KEY `clubmembership_ibfk_2` (`user_id`),
  CONSTRAINT `clubmembership_ibfk_1` FOREIGN KEY (`club_id`) REFERENCES `club` (`club_id`),
  CONSTRAINT `clubmembership_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clubmembership`
--

LOCK TABLES `clubmembership` WRITE;
/*!40000 ALTER TABLE `clubmembership` DISABLE KEYS */;
/*!40000 ALTER TABLE `clubmembership` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comment`
--

DROP TABLE IF EXISTS `comment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comment` (
  `comment_id` char(36) NOT NULL,
  `review_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `comment_text` text NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`comment_id`),
  KEY `comment_ibfk_1` (`review_id`),
  KEY `comment_ibfk_2` (`user_id`),
  CONSTRAINT `comment_ibfk_1` FOREIGN KEY (`review_id`) REFERENCES `review` (`review_id`),
  CONSTRAINT `comment_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comment`
--

LOCK TABLES `comment` WRITE;
/*!40000 ALTER TABLE `comment` DISABLE KEYS */;
INSERT INTO `comment` VALUES ('30e2f15e-8359-4e9b-a82c-e505df3b1074','56c2b469-d973-4bbf-a559-81ff3b2129d0','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','allo','2024-09-15 23:24:28',NULL,NULL,'2024-09-15 23:24:28'),('40746647-a759-416b-9b8c-fd8190a92237','56c2b469-d973-4bbf-a559-81ff3b2129d0','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','hây\n','2024-09-16 21:33:24',NULL,NULL,'2024-09-16 21:33:24'),('5f4ea480-e4e1-45b6-9afe-79af744cb12d','56c2b469-d973-4bbf-a559-81ff3b2129d0','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','hello','2024-09-15 23:24:05',NULL,NULL,'2024-09-15 23:24:05'),('610fdf90-731d-4a98-a079-5cd938cd4464','0a8c7b6d-a888-4dbd-9f4c-d3c4c5e85a8b','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','a','2024-09-21 23:30:14',NULL,NULL,'2024-09-21 23:30:14'),('74da1020-ea43-40bc-9c69-b98895fec5e6','56c2b469-d973-4bbf-a559-81ff3b2129d0','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','hello','2024-09-15 01:06:05',NULL,NULL,'2024-09-15 01:06:05'),('9bb006b8-1956-4326-89fd-198d918e5569','56c2b469-d973-4bbf-a559-81ff3b2129d0','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','hay','2024-09-15 00:52:20',NULL,NULL,'2024-09-15 00:52:20'),('d2d96470-6324-4d5b-9931-05eade596f59','0a8c7b6d-a888-4dbd-9f4c-d3c4c5e85a8b','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','hay','2024-09-21 23:31:17',NULL,NULL,'2024-09-21 23:31:17');
/*!40000 ALTER TABLE `comment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `follow`
--

DROP TABLE IF EXISTS `follow`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `follow` (
  `follow_id` char(36) NOT NULL,
  `follower_id` char(36) NOT NULL,
  `followed_id` char(36) NOT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`follow_id`),
  KEY `f_idx` (`follower_id`),
  KEY `f2_idx` (`followed_id`,`follower_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `follow`
--

LOCK TABLES `follow` WRITE;
/*!40000 ALTER TABLE `follow` DISABLE KEYS */;
/*!40000 ALTER TABLE `follow` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `friend`
--

DROP TABLE IF EXISTS `friend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `friend` (
  `user_id` char(36) NOT NULL,
  `friend_id` char(36) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`user_id`,`friend_id`),
  KEY `friend_id` (`friend_id`),
  CONSTRAINT `friend_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  CONSTRAINT `friend_ibfk_2` FOREIGN KEY (`friend_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `friend`
--

LOCK TABLES `friend` WRITE;
/*!40000 ALTER TABLE `friend` DISABLE KEYS */;
/*!40000 ALTER TABLE `friend` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `image`
--

DROP TABLE IF EXISTS `image`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `image` (
  `image_id` char(36) NOT NULL,
  `image_link` text NOT NULL,
  `object_id` char(36) NOT NULL,
  `is_default` tinyint DEFAULT '0',
  `image_name` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `image`
--

LOCK TABLES `image` WRITE;
/*!40000 ALTER TABLE `image` DISABLE KEYS */;
INSERT INTO `image` VALUES ('ec30cd6e-3ffe-4462-b3a1-bc3e467b425b','http://res.cloudinary.com/dqywrcgrr/image/upload/v1725792505/ec30cd6e-3ffe-4462-b3a1-bc3e467b425b.jpg','f6992751-6e30-4b4c-a1af-97f8b6594630',0,'3.jpg','0001-01-01 00:00:00','','','0001-01-01 00:00:00'),('03029640-0a02-41d2-a42e-ad167c461a27','http://res.cloudinary.com/dqywrcgrr/image/upload/v1725810897/03029640-0a02-41d2-a42e-ad167c461a27.jpg','640ea1a6-cdb2-4d81-86d7-c9c082fb4b4c',0,'2.jpg','0001-01-01 00:00:00','','','0001-01-01 00:00:00'),('ffcdb2ae-1d5d-42b2-b6de-20ad629ddf8d','http://res.cloudinary.com/dqywrcgrr/image/upload/v1725893470/ffcdb2ae-1d5d-42b2-b6de-20ad629ddf8d.jpg','87dfb43c-8ca8-4d60-8ba2-baa2cea6da33',0,'The Three-Body Problem.jpg','0001-01-01 00:00:00','','','0001-01-01 00:00:00'),('e0a75a0e-66b6-4473-83bb-c9046fe225e8','http://res.cloudinary.com/dqywrcgrr/image/upload/v1725893607/e0a75a0e-66b6-4473-83bb-c9046fe225e8.jpg','665486b8-047a-4860-b34a-5ed9f7b0a585',0,'The Fund.jpg','0001-01-01 00:00:00','','','0001-01-01 00:00:00'),('1c74d01a-f409-4723-be7c-05d8283da49a','http://res.cloudinary.com/dqywrcgrr/image/upload/v1725893688/1c74d01a-f409-4723-be7c-05d8283da49a.jpg','de53b690-a83b-4594-9168-347dfc89c2aa',0,'Number Go Up.jpg','0001-01-01 00:00:00','','','0001-01-01 00:00:00'),('1b4ddcd8-379a-41f0-9a15-b6d549698f31','http://res.cloudinary.com/dqywrcgrr/image/upload/v1726061021/1b4ddcd8-379a-41f0-9a15-b6d549698f31.jpg','fa0aa418-11d3-4bb1-8488-b61f8c0b4977',0,'Gender Queer.jpg','0001-01-01 00:00:00',NULL,NULL,'0001-01-01 00:00:00'),('af954a2b-d6c4-4ec6-a415-3e6a43a3dd5d','http://res.cloudinary.com/dqywrcgrr/image/upload/v1726935792/af954a2b-d6c4-4ec6-a415-3e6a43a3dd5d.jpg','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',0,'3.jpg','0001-01-01 00:00:00',NULL,NULL,'0001-01-01 00:00:00'),('1b6a6a82-0dfb-481c-93bf-1f7c268bf841','http://res.cloudinary.com/dqywrcgrr/image/upload/v1727453854/1b6a6a82-0dfb-481c-93bf-1f7c268bf841.jpg','2c4cd974-58c4-4b10-a5c7-94c4177dc24f',0,'Number Go Up.jpg','0001-01-01 00:00:00',NULL,NULL,'0001-01-01 00:00:00');
/*!40000 ALTER TABLE `image` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `like`
--

DROP TABLE IF EXISTS `like`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `like` (
  `like_id` char(36) NOT NULL,
  `user_id` char(36) DEFAULT NULL,
  `review_id` char(36) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`like_id`),
  KEY `review_id` (`review_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `like_ibfk_1` FOREIGN KEY (`review_id`) REFERENCES `review` (`review_id`),
  CONSTRAINT `like_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `like`
--

LOCK TABLES `like` WRITE;
/*!40000 ALTER TABLE `like` DISABLE KEYS */;
INSERT INTO `like` VALUES ('1610eef3-445f-4b81-a75c-e44101add7b5','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','0a8c7b6d-a888-4dbd-9f4c-d3c4c5e85a8b','2024-09-21 22:25:30',NULL,NULL,'2024-09-21 22:25:30'),('232e5297-7867-4b2a-a1b4-df8866fb22e6','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','56c2b469-d973-4bbf-a559-81ff3b2129d0','2024-09-15 16:08:22',NULL,NULL,'2024-09-15 16:08:22'),('33908152-739c-434c-8dec-ec2db1636f33','a328257e-5594-45de-a0cf-12d5cb54c47a','56c2b469-d973-4bbf-a559-81ff3b2129d0','2024-09-15 16:03:41',NULL,NULL,'2024-09-15 16:03:41'),('7c1b2b45-01c1-4613-904e-7e345f1f8de2','77710fc2-e2e1-4d94-a845-32f714be3b1c','56c2b469-d973-4bbf-a559-81ff3b2129d0','2024-09-15 17:46:31',NULL,NULL,'2024-09-15 17:46:31');
/*!40000 ALTER TABLE `like` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification`
--

DROP TABLE IF EXISTS `notification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification` (
  `notification_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `type` varchar(50) DEFAULT NULL,
  `content` text,
  `is_read` tinyint(1) DEFAULT '0',
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`notification_id`),
  KEY `notification_ibfk_1` (`user_id`),
  CONSTRAINT `notification_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification`
--

LOCK TABLES `notification` WRITE;
/*!40000 ALTER TABLE `notification` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `post`
--

DROP TABLE IF EXISTS `post`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `post` (
  `post_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `content` text,
  `image_url` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`post_id`),
  KEY `post_ibfk_1` (`user_id`),
  CONSTRAINT `post_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `post`
--

LOCK TABLES `post` WRITE;
/*!40000 ALTER TABLE `post` DISABLE KEYS */;
/*!40000 ALTER TABLE `post` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `review`
--

DROP TABLE IF EXISTS `review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `review` (
  `review_id` char(36) NOT NULL,
  `book_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `rating` int DEFAULT NULL,
  `review_text` text,
  `likes_count` int DEFAULT '0',
  `dislikes_count` int DEFAULT '0',
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  `status` int DEFAULT '1',
  PRIMARY KEY (`review_id`),
  KEY `review_ibfk_1` (`book_id`),
  KEY `review_ibfk_2` (`user_id`),
  CONSTRAINT `review_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`),
  CONSTRAINT `review_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `review`
--

LOCK TABLES `review` WRITE;
/*!40000 ALTER TABLE `review` DISABLE KEYS */;
INSERT INTO `review` VALUES ('0a8c7b6d-a888-4dbd-9f4c-d3c4c5e85a8b','87dfb43c-8ca8-4d60-8ba2-baa2cea6da33','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',NULL,'<p>The story kicks off with a genuinely intriguing premise&mdash;<strong>a disease outbreak</strong>&nbsp;that warps love and affection into something dark and deadly,&nbsp;<strong>turning people&rsquo;s emotions into bloodlust</strong>. Taku Kamishiro, the protagonist,&nbsp;<strong>battling his own murderous urges towards his crush</strong>, Mika Hanazono,&nbsp;<strong>while also protecting her from being killed by her many followers</strong>. With its&nbsp;<strong>fast pace</strong>&nbsp;and a decent art style, it should have made for a tense, gripping narrative, but unfortunately,&nbsp;<strong>bland characters</strong>&nbsp;and poor execution drag it down, and what could&rsquo;ve been a standout series ends up being painfully mediocre. It&rsquo;s frustrating because you can see the potential, but it just doesn&rsquo;t deliver anything beyond&nbsp;<strong>a forgettable experience</strong>.</p>',0,0,'2024-09-15 23:02:15',NULL,NULL,'2024-09-15 23:02:15',2),('56c2b469-d973-4bbf-a559-81ff3b2129d0','de53b690-a83b-4594-9168-347dfc89c2aa','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',NULL,'<p>When I dive into survival&nbsp;<span data-reactid=\".5\"><span data-reactid=\".5.0\"><button class=\"gr-buttonAsLink\" data-reactid=\".5.0.1\">(view spoiler)</button></span></span>&nbsp;thrillers, I seek emotional squalls. I yearn for characters who tug at my soul&mdash;heroes to cheer, villains to loathe. I want to care, desperately, for these souls battling the tempest. But here, the contestants evoke no storms within me. No love, no hate&mdash;just indifference. Instead, they drift like forgotten flotsam.<br><br>As I sail onward, hoping for creative currents, I find myself anticipating the typical tropes and twists associated with this genre. For some, these elements are a siren call; for me, they&rsquo;re the iceberg that sinks interest. When a tale fails to ignite, it may be best to bid it farewell.<br><br>Books are like ships, some lead to treasure, others to forgotten depths. And \"The Last Passenger\", with its&nbsp;<strong>lacklustre characters and predictable plot twists</strong>, made it difficult to stay on board. If you\'re seeking a fresh and original take on the survival thriller genre, this book may not be the best choice.</p>',0,0,'2024-09-14 14:17:37',NULL,NULL,'2024-09-14 14:17:37',1),('66129572-8b1a-4012-bed5-fa111125481f','fa0aa418-11d3-4bb1-8488-b61f8c0b4977','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',NULL,'<p>When I dive into survival&nbsp;<span data-reactid=\".5\"><span data-reactid=\".5.0\"><button class=\"gr-buttonAsLink\" data-reactid=\".5.0.1\">(view spoiler)</button></span></span>&nbsp;thrillers, I seek emotional squalls. I yearn for characters who tug at my soul&mdash;heroes to cheer, villains to loathe. I want to care, desperately, for these souls battling the tempest. But here, the contestants evoke no storms within me. No love, no hate&mdash;just indifference. Instead, they drift like forgotten flotsam.<br><br>As I sail onward, hoping for creative currents, I find myself anticipating the typical tropes and twists associated with this genre. For some, these elements are a siren call; for me, they&rsquo;re the iceberg that sinks interest. When a tale fails to ignite, it may be best to bid it farewell.<br><br>Books are like ships, some lead to treasure, others to forgotten depths. And \"The Last Passenger\", with its&nbsp;<strong>lacklustre characters and predictable plot twists</strong>, made it difficult to stay on board. If you\'re seeking a fresh and original take on the survival thriller genre, this book may not be the best choice.</p>',0,0,'2024-09-14 14:19:08',NULL,NULL,'2024-09-14 14:19:08',1);
/*!40000 ALTER TABLE `review` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reviewbookuser`
--

DROP TABLE IF EXISTS `reviewbookuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reviewbookuser` (
  `book_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `rating` int DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`book_id`,`user_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `reviewbookuser_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`),
  CONSTRAINT `reviewbookuser_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reviewbookuser`
--

LOCK TABLES `reviewbookuser` WRITE;
/*!40000 ALTER TABLE `reviewbookuser` DISABLE KEYS */;
INSERT INTO `reviewbookuser` VALUES ('665486b8-047a-4860-b34a-5ed9f7b0a585','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',5,'2024-09-21 22:25:45',NULL,NULL,'2024-09-21 22:25:45'),('87dfb43c-8ca8-4d60-8ba2-baa2cea6da33','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',3,'2024-09-15 23:02:15',NULL,NULL,'2024-09-15 23:02:15'),('87dfb43c-8ca8-4d60-8ba2-baa2cea6da33','2c4cd974-58c4-4b10-a5c7-94c4177dc24f',4,'2024-09-22 18:38:47',NULL,NULL,'2024-09-22 18:38:47'),('de53b690-a83b-4594-9168-347dfc89c2aa','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',2,'2024-09-14 14:17:37',NULL,NULL,'2024-09-14 14:17:37'),('de53b690-a83b-4594-9168-347dfc89c2aa','77710fc2-e2e1-4d94-a845-32f714be3b1c',1,'2024-09-15 16:59:16',NULL,NULL,'2024-09-15 16:59:16'),('de53b690-a83b-4594-9168-347dfc89c2aa','c00285bb-27d3-41ac-910a-c61cf634257c',1,'2024-09-15 18:16:27',NULL,NULL,'2024-09-15 18:16:27'),('fa0aa418-11d3-4bb1-8488-b61f8c0b4977','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d',5,'2024-09-14 14:19:08',NULL,NULL,'2024-09-14 14:19:08'),('fa0aa418-11d3-4bb1-8488-b61f8c0b4977','c00285bb-27d3-41ac-910a-c61cf634257c',3,'2024-09-15 18:20:29',NULL,NULL,'2024-09-15 18:20:29');
/*!40000 ALTER TABLE `reviewbookuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `socialinteraction`
--

DROP TABLE IF EXISTS `socialinteraction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `socialinteraction` (
  `social_interaction_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `interaction_type` enum('Like','Comment','Share') NOT NULL,
  `post_id` char(36) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`social_interaction_id`),
  KEY `post_id` (`post_id`),
  KEY `socialinteraction_ibfk_1` (`user_id`),
  CONSTRAINT `socialinteraction_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  CONSTRAINT `socialinteraction_ibfk_2` FOREIGN KEY (`post_id`) REFERENCES `post` (`post_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `socialinteraction`
--

LOCK TABLES `socialinteraction` WRITE;
/*!40000 ALTER TABLE `socialinteraction` DISABLE KEYS */;
/*!40000 ALTER TABLE `socialinteraction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` char(36) NOT NULL,
  `user_name` varchar(255) DEFAULT NULL,
  `fullname` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `profile_picture` varchar(255) DEFAULT NULL,
  `social_login_provider` varchar(50) DEFAULT NULL,
  `bio` text,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(255) DEFAULT NULL,
  `modified_by` varchar(255) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  `phone` varchar(45) DEFAULT NULL,
  `role` int DEFAULT '0',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','','băng','bang@gmail.com','9F42BA58FD72DDF7E20D2457F660A981','','','','2024-09-09 21:56:08','','','2024-09-21 23:22:50','0328669613',0),('2c4cd974-58c4-4b10-a5c7-94c4177dc24f',NULL,'ADMIN','admin@gmail.com','21232F297A57A5A743894A0E4A801FC3',NULL,NULL,NULL,'2024-09-15 18:11:38',NULL,NULL,'2024-09-27 23:17:31',NULL,1),('77710fc2-e2e1-4d94-a845-32f714be3b1c',NULL,'Nguyễn Văn Băng','bang1@gmail.com','9F42BA58FD72DDF7E20D2457F660A981',NULL,NULL,NULL,'2024-09-15 16:05:36',NULL,NULL,'2024-09-15 16:05:36',NULL,0),('a328257e-5594-45de-a0cf-12d5cb54c47a','','Nguyễn Văn Dương','nvduong@gmail.com','CE67A542BA3298E1B48042B5E94D5EC9','','','','2024-09-08 17:00:35','','','2024-09-08 17:00:35',NULL,0),('c00285bb-27d3-41ac-910a-c61cf634257c',NULL,'Tà Vô Nguyệt','nguyet@gmail.com','2188699F07ADFDB23BE2FEBD24E0B462',NULL,NULL,NULL,'2024-09-15 18:12:46',NULL,NULL,'2024-09-15 18:12:46',NULL,0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usertoken`
--

DROP TABLE IF EXISTS `usertoken`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usertoken` (
  `user_token_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  `token` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL,
  `expired_at` datetime NOT NULL,
  `ip_address` varchar(30) NOT NULL,
  `is_remember_password` tinyint DEFAULT NULL,
  `enum_role` tinyint DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`user_token_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usertoken`
--

LOCK TABLES `usertoken` WRITE;
/*!40000 ALTER TABLE `usertoken` DISABLE KEYS */;
INSERT INTO `usertoken` VALUES ('02d12d58-de66-4bf3-964c-947c2d332703','2c4cd974-58c4-4b10-a5c7-94c4177dc24f','t7Kuvlr9JnjA5+8KWZPdrHsMZUmSTIcPD0cL+4HWMSQ=','2024-09-27 23:31:34','2024-09-29 23:31:34','',NULL,1,NULL),('07c582bf-dc2d-481f-a734-31f4bc62f2ce','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','+lUR5ejdz1o9DiDBJmwFGNpsm9Lw9P9VGEaNUb1Gdg4=','2024-09-16 21:32:09','2024-09-18 21:32:09','',NULL,1,''),('0d54706f-a0bd-4858-abcc-0eca990a06f9','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','3+Rsgdcb+aqWuLRCFNtNsO2I0P+Jbi69VvA79vG4t00=','2024-09-21 23:29:19','2024-09-23 23:29:19','',NULL,1,NULL),('14982a48-c3d6-4528-8b7a-260cc2c7c4b4','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','8a7pR75S+Gnt+tW1ZkWMI2e5fDidC50BfgsrWjUqmqE=','2024-09-09 21:56:08','2024-09-11 21:56:08','',NULL,1,''),('1f3cbad1-64bc-4e43-aba9-17c8e311003e','2c4cd974-58c4-4b10-a5c7-94c4177dc24f','pcpkyYDoFF+Inzol2IXCI6CW29J6RCCBA+R2wW+4qm8=','2024-09-15 18:11:38','2024-09-17 18:11:38','',NULL,1,NULL),('27b39d0a-c1a4-44af-8267-502f1bd3556d','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','oFrfW0nkQmm9mjVWpQUH++pHzgI+erB0vScnKCLjVh8=','2024-09-16 21:32:57','2024-09-18 21:32:57','',NULL,1,''),('3038c3f9-38ac-4869-b477-2ecbe1821e9a','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','yr6sNWysdx61TM2IzfpyKN3zyOUynuBKC+4vIYLkmc0=','2024-09-09 22:10:11','2024-09-11 22:10:11','',NULL,1,''),('3d80ad8f-6d72-4ca3-84a6-52b51afbaa12','77710fc2-e2e1-4d94-a845-32f714be3b1c','kEc1ZlKWfZO6EjQEHj3atwIZqghYLiFNyhxE4gyM0Vs=','2024-09-15 16:07:21','2024-09-17 16:07:21','',NULL,1,NULL),('4245b43d-c135-4579-a829-4d270d752c28','c00285bb-27d3-41ac-910a-c61cf634257c','Bbk2mxueehUrbIByGwktgSvcoLQy+GJ+88BYsVLFFKA=','2024-09-15 18:12:46','2024-09-17 18:12:46','',NULL,1,NULL),('5b789c2a-ac68-485c-a73a-86b4b66a3a53','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','Wq6T68F4du5EAZMOWQE6es53dXPLGW2McGQYaDvUTkQ=','2024-09-09 21:59:26','2024-09-11 21:59:26','',NULL,1,''),('627cf4f7-9887-43b0-ac0a-58bab028efa6','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','5abfkAIHu0AEBoXfyd8QxrYTsHwYToZxw9VvvXTbfKQ=','2024-09-15 16:07:49','2024-09-17 16:07:49','',NULL,1,''),('65605db3-6348-4bd2-b2ed-60f38f20f5b2','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','+dGGyBZvvnVtwXpcShNYj3qPNOaLfyUmCOgRTTWjRFI=','2024-09-15 23:24:18','2024-09-17 23:24:18','',NULL,1,''),('6f412ddd-5e60-46d8-bf36-f67fab4c1e8e','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','8Ok28YmFHXMLGY+zcKt+oL1hNUcpm3ZHWA9iGwfqaRY=','2024-09-15 23:16:23','2024-09-17 23:16:23','',NULL,1,''),('80b1c72c-acb2-48cb-94bd-6d11a17e0ef1','a328257e-5594-45de-a0cf-12d5cb54c47a','B4hxoajFTdxpQKiN6rnONYwn4QxZ3MKADb7lms2RFq4=','2024-09-15 01:59:02','2024-09-17 01:59:02','',NULL,1,''),('81c07d1a-9e99-479b-a330-64703e114e0d','77710fc2-e2e1-4d94-a845-32f714be3b1c','9PZIJ72XoJDb8F1zbtokuhSLh1cX22b1hI9zZdwdqZM=','2024-09-15 16:05:36','2024-09-17 16:05:36','',NULL,1,NULL),('89dd4246-dc89-4be0-9ba5-dd3675019fd9','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','qzfpDxLHgnpt4jgYxKjOY8pGTRbNJok4KI4Wk9FgCHg=','2024-09-15 19:47:00','2024-09-17 19:47:00','',NULL,1,''),('9664b54e-d992-4467-9d24-4695aecfd6f1','2c4cd974-58c4-4b10-a5c7-94c4177dc24f','ow+G+tiAcRgBeamIeKhuRrKRa9oaob8+nueq+IfCG5U=','2024-09-15 19:46:05','2024-09-17 19:46:05','',NULL,1,NULL),('9e43e3db-9c81-4b22-95c4-0ee7f581b144','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','ySQTDFdAdvoOwF9bVV+bEJ+fDrDD0mnJ64aB+A2x3gc=','2024-09-18 23:23:05','2024-09-20 23:23:05','',NULL,1,''),('9e827274-0250-40f3-bf15-bdfc5fcdd201','2c4cd974-58c4-4b10-a5c7-94c4177dc24f','M80Hg98s2eiybkOw5qMVnF2t99+Ik5p+EKJvlWgDcfQ=','2024-09-27 23:17:44','2024-09-29 23:17:44','',NULL,1,NULL),('b96ce1ce-d75a-499a-8fae-c63c8c1bea29','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','wl8g624RSpJ+IjsAusgxgxlReeZitKiPIOx8AUo452g=','2024-09-09 21:57:12','2024-09-11 21:57:12','',NULL,1,''),('b9c3a362-d963-4f48-8e0a-b9bfddddbd32','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','4cc2bQYPHgRCRyeFBy+F0NdPvlkvsfny8BunezHePDA=','2024-09-21 23:24:37','2024-09-23 23:24:37','',NULL,1,''),('ba5bf523-1435-4789-99ec-8f688156fd23','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','zxBTrm03zHfPeZWv5ek2EZJJDEmgbTjcRJKDctfPSAs=','2024-09-19 20:31:24','2024-09-21 20:31:24','',NULL,1,''),('cb6676c8-7a2e-43cc-b817-5e41034bf8d0','a328257e-5594-45de-a0cf-12d5cb54c47a','+9rRNab0+2csM3pGKLXTh+0FIWH1QU40TDi6aS0JrxA=','2024-09-08 18:46:09','2024-09-10 18:46:09','',NULL,1,''),('cd6c09be-210c-453e-a70d-2258d595bc6a','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','cywAexTOzsgdY8KLE4GBU3fCyxHMR5b4ObEfw5ItVx0=','2024-09-18 23:20:38','2024-09-20 23:20:38','',NULL,1,''),('d01cf916-fc83-4292-b1ff-9e65dd441af3','a328257e-5594-45de-a0cf-12d5cb54c47a','F4I6Pv7cZ2JK1ZlvZaWrRE9AqX+uqkLKudisUPaZcF0=','2024-09-15 19:46:20','2024-09-17 19:46:20','',NULL,1,''),('d0f9ca22-3f76-4a7e-9424-d1d7da321626','2c4cd974-58c4-4b10-a5c7-94c4177dc24f','X2W3sZ17UUc758HukTisjfsAl1g0B+vyxjqjPucjXRM=','2024-09-27 23:32:12','2024-09-29 23:32:12','',NULL,1,NULL),('e55051e8-b428-467a-85c3-f2c59972894b','a328257e-5594-45de-a0cf-12d5cb54c47a','OCQXf8Fb6+cKDjLrg2mTsUQ9aL4m3HMp+x3GezKW0HU=','2024-09-08 17:00:36','2024-09-10 17:00:36','',NULL,1,''),('e5d3e39d-756e-4a31-b2ff-2f492621e7f0','a328257e-5594-45de-a0cf-12d5cb54c47a','uGP1oGTCl++zfcZmGKU+wypr2qxmf2UJZEyOVmBdA1Y=','2024-09-09 21:45:11','2024-09-11 21:45:11','',NULL,1,''),('ed034a79-9bac-46b5-826b-639417c84642','2c4cd974-58c4-4b10-a5c7-94c4177dc24f','jQm1lqxoCyeMgrzxf+hx+rTnR6b1uV3CxVBX9IpDZgY=','2024-09-22 18:38:27','2024-09-24 18:38:27','',NULL,1,NULL),('eebe3a3c-1984-4217-8698-e1f3fab2a309','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','q+hyI1+phF0FaMbPwbLPpD1acwWseksQgbT35ThBGF4=','2024-09-15 15:44:07','2024-09-17 15:44:07','',NULL,1,''),('ff421e8f-1cb7-4bd7-9f66-d16a10ba5353','2878c0b4-1d5f-4cab-aaf6-34f0fd84da1d','NJyqNj8FdkQ2pWnyi1D1dVcjSSHmGj6z3WsblO7k+qs=','2024-09-18 20:11:26','2024-09-20 20:11:26','',NULL,1,'');
/*!40000 ALTER TABLE `usertoken` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'bookreviews'
--

--
-- Dumping routines for database 'bookreviews'
--
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Book_AdminBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Book_AdminBook`(IN p_TextSearch VARCHAR(255),IN p_Status int,IN p_SortDirection varchar(4), IN p_PageNumber TINYINT, IN p_PageSize TINYINT, OUT TotalRecords int)
BEGIN

  CREATE TEMPORARY TABLE IF NOT EXISTS tblOrginal AS


     SELECT ROW_NUMBER() OVER ( partition by b.book_id order by b.created_at desc)   AS RowIndex,

      b.book_id,
	  b.book_name,
	  b.author_name,
	  b.author_id,
	  b.genre,
	  b.isbn,
	  b.publication_date,
	  b.description,
	  b.avg_rate,
	  b.created_at,
	  b.created_by,
	  b.modified_by,
	  b.modified_at,
	  b.user_id,
	  b.book_review,
	  i.image_link as cover_image,
		u.fullname,
        b.status
  FROM book b 
  join `user` u on u.user_id = b.user_id
  left join image i on i.object_id = b.book_id
  WHERE (p_TextSearch IS NULL
  OR b.book_name LIKE CONCAT('%', p_TextSearch, '%')
  OR b.author_name LIKE CONCAT('%', p_TextSearch, '%'))
  and ((p_Status = -1 and b.`status` <> 2 ) or p_Status = b.`status`);

  SET @indexFirst = p_PageNumber * p_PageSize - p_PageSize + 1;



  SET @indexLast = p_PageNumber * p_PageSize;
  
 
    
  SELECT

    *

  FROM tblOrginal do

  WHERE do.RowIndex BETWEEN @indexFirst AND @indexLast
  order by RowIndex DESC ;
  
  SET TotalRecords = (SELECT

      COUNT(*)

    FROM tblOrginal) ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Book_GetBookDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Book_GetBookDetail`(p_BookId char(36),p_UserId char(36))
BEGIN
	select   
    b.book_id,
	b.book_name,
  b.author_name,
  b.author_id,
  b.genre,
  b.isbn,
  b.publication_date,
  b.description,
  b.avg_rate,
  b.created_at,
  b.created_by,
  b.modified_by,
  b.modified_at,
  b.user_id,
  b.book_review,
  i.image_link as cover_image,
  i2.image_link as user_image,
  rbu.rating as user_rating, 
  bli.book_list_item_id as book_list_item_id,
  bl.list_type
    from book b
    left join image i on i.object_id = b.book_id
    left join image i2 on i2.object_id = b.user_id
    left join reviewbookuser rbu on rbu.book_id = b.book_id and rbu.user_id = p_UserId
	left join booklistitem bli on bli.book_id = b.book_id
	left join booklist bl on bl.book_list_id = bli.book_list_id and bl.user_id = p_UserId
    where b.book_id = p_BookId; 
    
    
    select   
    b.book_id,
    b.user_id,
    u.fullname,
    fl.follow_id,
    case when fl.follow_id is not null then true else false end as is_follow,
    (
		select count(*)  from book bk where bk.user_id = b.user_id 
	) as total_book,
    (
		select count(*)  from follow fll where fll.followed_id = b.user_id 
	) as total_follow,
    (
		select count(*)  from reviewbookuser rvbu where rvbu.book_id = b.book_id
	) as total_rating,
    (
		select count(*)  from reviewbookuser rvbu where rvbu.book_id = b.book_id and  rvbu.rating = 1
	) as total_rating_1,
    (
		select count(*)  from reviewbookuser rvbu where rvbu.book_id = b.book_id and  rvbu.rating = 2
	) as total_rating_2,
    (
		select count(*)  from reviewbookuser rvbu where rvbu.book_id = b.book_id and  rvbu.rating = 3
	) as total_rating_3,
    (
		select count(*)  from reviewbookuser rvbu where rvbu.book_id = b.book_id and  rvbu.rating = 4
	) as total_rating_4,
    (
		select count(*)  from reviewbookuser rvbu where rvbu.book_id = b.book_id and  rvbu.rating = 5
	) as total_rating_5
	from book b
    join `user` u on u.user_id = b.user_id 
    left join follow fl on fl.followed_id = b.user_id
	where b.book_id = p_BookId; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Book_GetByFilter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Book_GetByFilter`(IN p_TextSearch VARCHAR(255),IN p_ListType int,IN p_SortColumn varchar(255),IN p_SortDirection varchar(4), IN p_PageNumber TINYINT, IN p_PageSize TINYINT,IN p_UserId char(36), OUT TotalRecords int)
BEGIN

  CREATE TEMPORARY TABLE IF NOT EXISTS tblOrginal AS


     SELECT ROW_NUMBER() OVER ( partition by b.book_id )   AS RowIndex,

    b.*,i.image_link as cover_image, bl.list_type as list_type,bli.book_list_item_id

  FROM booklist bl 
  JOIN booklistitem bli ON bl.book_list_id = bli.book_list_id 
  JOIN book b ON b.book_id = bli.book_id 
  LEFT JOIN image i on b.book_id = i.object_id

  WHERE (p_TextSearch IS NULL

  OR b.book_name LIKE CONCAT('%', p_TextSearch, '%')
  OR b.author_name LIKE CONCAT('%', p_TextSearch, '%'))
  and (p_ListType = -1 or bl.list_type = p_ListType )
  and (p_UserId is null or bl.user_id = p_UserId)
   ORDER BY
    CASE 
      WHEN p_SortColumn = 'book_name' THEN b.book_name
      WHEN p_SortColumn = 'publication_date' THEN b.publication_date
      WHEN p_SortColumn = 'avg_rate' THEN b.avg_rate
      ELSE bli.modified_at
    END , -- Điều kiện ASC mặc định
    IF(p_SortDirection = 'DESC', 1, 0);

  SET @indexFirst = p_PageNumber * p_PageSize - p_PageSize + 1;



  SET @indexLast = p_PageNumber * p_PageSize;
  
 
    
  SELECT

    *

  FROM tblOrginal do

  WHERE do.RowIndex BETWEEN @indexFirst AND @indexLast;

	SELECT 
    SUM(CASE WHEN do.list_type = 1 THEN 1 ELSE 0 END) AS WantToRead,
    SUM(CASE WHEN do.list_type = 2 THEN 1 ELSE 0 END) AS Reading,
    SUM(CASE WHEN do.list_type = 3 THEN 1 ELSE 0 END) AS `Read`,
    COUNT(*) as AllRead
FROM tblOrginal do;
    SET TotalRecords = (SELECT

      COUNT(*)

    FROM tblOrginal) ;

  DROP TEMPORARY TABLE IF EXISTS tblOrginal;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Book_GetByISBN` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Book_GetByISBN`(p_ISBN nvarchar(100))
BEGIN
	select * from `book` where isbn = p_ISBN;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Book_GetMyBookByFilter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Book_GetMyBookByFilter`(IN p_TextSearch VARCHAR(255),IN p_ListType int,IN p_SortColumn varchar(255),IN p_SortDirection varchar(4), IN p_PageNumber TINYINT, IN p_PageSize TINYINT,IN p_UserId char(36))
BEGIN



  CREATE TEMPORARY TABLE IF NOT EXISTS tblOrginal AS


     SELECT ROW_NUMBER() OVER ( partition by b.book_id order by case when p_SortColumn = '' or p_SortColumn is null then CONCAT(bli.modified_at, ' ',p_SortDirection)  else CONCAT(p_SortColumn, ' ',p_SortDirection) end )   AS RowIndex,

    b.*,i.image_id,i.image_link,i.image_name

  FROM booklist bl 
  JOIN booklistitem bli ON bl.book_list_id = bli.book_list_id 
  JOIN book b ON b.book_id = bli.book_id 
  LEFT JOIN image i on b.book_id = i.object_id

  WHERE (p_TextSearch IS NULL

  OR b.book_name LIKE CONCAT('%', p_TextSearch, '%')
  OR b.author_name LIKE CONCAT('%', p_TextSearch, '%'))
  and (p_ListType = 0 or bl.list_type = p_ListType )
  and (p_UserId is null or bl.user_id = p_UserId);

  SET @indexFirst = p_PageNumber * p_PageSize - p_PageSize + 1;



  SET @indexLast = p_PageNumber * p_PageSize;

  SELECT

    *

  FROM tblOrginal do

  WHERE do.RowIndex BETWEEN @indexFirst AND @indexLast;



  DROP TEMPORARY TABLE IF EXISTS tblOrginal;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Book_SearchBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Book_SearchBook`(IN p_TextSearch VARCHAR(255),IN p_ListType int,IN p_SortColumn varchar(255),IN p_SortDirection varchar(4), IN p_PageNumber TINYINT, IN p_PageSize TINYINT,IN p_UserId char(36), OUT TotalRecords int)
BEGIN

  CREATE TEMPORARY TABLE IF NOT EXISTS tblOrginal AS


     SELECT ROW_NUMBER() OVER ( partition by b.book_id )   AS RowIndex,

    b.*,i.image_link as cover_image

  FROM book b 
  LEFT JOIN image i on b.book_id = i.object_id

  WHERE (p_TextSearch IS NULL

  OR b.book_name LIKE CONCAT('%', p_TextSearch, '%')
  OR b.author_name LIKE CONCAT('%', p_TextSearch, '%'))
   ORDER BY
    CASE 
      WHEN p_SortColumn = 'book_name' THEN b.book_name
      WHEN p_SortColumn = 'publication_date' THEN b.publication_date
      WHEN p_SortColumn = 'avg_rate' THEN b.avg_rate
      ELSE b.created_at
    END , -- Điều kiện ASC mặc định
    IF(p_SortDirection = 'DESC', 1, 0);

  SET @indexFirst = p_PageNumber * p_PageSize - p_PageSize + 1;



  SET @indexLast = p_PageNumber * p_PageSize;
  
 
    
  SELECT

    *

  FROM tblOrginal do

  WHERE do.RowIndex BETWEEN @indexFirst AND @indexLast;
    SET TotalRecords = (SELECT

      COUNT(*)

    FROM tblOrginal) ;

  DROP TEMPORARY TABLE IF EXISTS tblOrginal;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Book_SearchData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Book_SearchData`(IN p_TextSearch VARCHAR(255),IN p_ListType int,IN p_SortColumn varchar(255),IN p_SortDirection varchar(4), IN p_PageNumber TINYINT, IN p_PageSize TINYINT,IN p_UserId char(36), OUT TotalRecords int)
BEGIN

  CREATE TEMPORARY TABLE IF NOT EXISTS tblOrginal AS


     SELECT ROW_NUMBER() OVER ( partition by b.book_id )   AS RowIndex,

   b.book_id,
  b.book_name,
  b.author_name,
  b.author_id,
  b.genre,
  b.isbn,
  b.publication_date,
  b.description,
  b.avg_rate,
  b.created_at,
  b.created_by,
  b.modified_by,
  b.modified_at,
  b.user_id,
  b.book_review,
  i.image_link as cover_image,
  rbu.rating as user_rating, 
  bli.book_list_item_id as book_list_item_id,
  bl.list_type

  FROM book b 
  LEFT JOIN image i on b.book_id = i.object_id
  left join reviewbookuser rbu on rbu.book_id = b.book_id and rbu.user_id = p_UserId
  left join booklistitem bli on bli.book_id = b.book_id
  left join booklist bl on bl.book_list_id = bli.book_list_id and bl.user_id = p_UserId
  WHERE (p_TextSearch IS NULL

  OR b.book_name LIKE CONCAT('%', p_TextSearch, '%')
  OR b.author_name LIKE CONCAT('%', p_TextSearch, '%'))
  group by  b.book_id,
  b.book_name,
  b.author_name,
  b.author_id,
  b.genre,
  b.isbn,
  b.publication_date,
  b.description,
  b.avg_rate,
  b.created_at,
  b.created_by,
  b.modified_by,
  b.modified_at,
  b.user_id,
  b.book_review,
  i.image_link ,rbu.rating
   ORDER BY
    CASE 
      WHEN p_SortColumn = 'book_name' THEN b.book_name
      WHEN p_SortColumn = 'publication_date' THEN b.publication_date
      WHEN p_SortColumn = 'avg_rate' THEN b.avg_rate
      ELSE b.created_at
    END , -- Điều kiện ASC mặc định
    IF(p_SortDirection = 'DESC', 1, 0);

  SET @indexFirst = p_PageNumber * p_PageSize - p_PageSize + 1;



  SET @indexLast = p_PageNumber * p_PageSize;
  
 
    
  SELECT

    *

  FROM tblOrginal do

  WHERE do.RowIndex BETWEEN @indexFirst AND @indexLast;
    SET TotalRecords = (SELECT

      COUNT(*)

    FROM tblOrginal) ;

  DROP TEMPORARY TABLE IF EXISTS tblOrginal;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Book_UpdateAVGStartBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Book_UpdateAVGStartBook`(IN p_bookId char(36))
BEGIN
	update `book` b
    set avg_rate = round((
		select avg(rbu.rating)
        from reviewbookuser rbu
        where rbu.book_id = p_bookId
    ),1)
    where b.book_id = p_bookId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Review_AdminReview` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Review_AdminReview`(IN p_TextSearch VARCHAR(255),IN p_Status int,IN p_SortDirection varchar(4), IN p_PageNumber TINYINT, IN p_PageSize TINYINT, OUT TotalRecords int)
BEGIN

  CREATE TEMPORARY TABLE IF NOT EXISTS tblOrginal AS


     SELECT ROW_NUMBER() OVER ( partition by rv.review_id order by rv.created_at Desc)   AS RowIndex,

    rv.*,
    b.book_name, 
    b.author_name , 
    b.genre,
    b.isbn,
    b.publication_date,
    b.book_review,
    b.description,
    i2.image_link as image_user_post,
    u.fullname
  FROM review rv
  join book b on b.book_id = rv.book_id
  join `user` u on u.user_id = rv.user_id
  left join image i2 on i2.object_id = u.user_id
  WHERE (p_TextSearch IS NULL
  OR b.book_name LIKE CONCAT('%', p_TextSearch, '%')
  OR b.author_name LIKE CONCAT('%', p_TextSearch, '%'))
  and ((p_Status = -1 and rv.`status` <> 2 ) or p_Status = rv.`status`);

  SET @indexFirst = p_PageNumber * p_PageSize - p_PageSize + 1;



  SET @indexLast = p_PageNumber * p_PageSize;
  
 
    
  SELECT

    *

  FROM tblOrginal do

  WHERE do.RowIndex BETWEEN @indexFirst AND @indexLast
  order by RowIndex DESC ;
  
  SET TotalRecords = (SELECT

      COUNT(*)

    FROM tblOrginal) ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Review_GetReviewPost` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Review_GetReviewPost`(IN p_TextSearch VARCHAR(255),IN p_ListType int,IN p_SortColumn varchar(255),IN p_SortDirection varchar(4), IN p_PageNumber TINYINT, IN p_PageSize TINYINT,IN p_UserId char(36))
BEGIN

  CREATE TEMPORARY TABLE IF NOT EXISTS tblOrginal AS


     SELECT ROW_NUMBER() OVER ( partition by rv.review_id order by case when p_SortColumn = 'book_name' 
																		then b.book_name 
																	 when p_SortColumn = 'publication_date' 
																		then b.publication_date
                                                                     when p_SortColumn = 'avg_rate' 
																		then b.avg_rate
																	else rv.created_at end DESC)   AS RowIndex,

    rv.*,
    b.book_name, 
    b.author_name , 
    b.genre,
    b.isbn,
    b.publication_date,
    b.book_review,
    b.description,
    b.avg_rate,
    i1.image_link as image_book, 
    i2.image_link as image_user_post,
    blid.list_type, 
    blid.book_list_item_id,
    rbu.rating as user_rating,
    (
      SELECT JSON_ARRAYAGG(
        JSON_OBJECT(
          'comment_id', c.comment_id,
          'comment_text', c.comment_text,
          'user_id', c.user_id,
          'fullname',COALESCE( ur.fullname,''),
          'image_user', COALESCE(i.image_link, 'https://scontent-hkg1-1.xx.fbcdn.net/v/t1.30497-1/453178253_471506465671661_2781666950760530985_n.png?stp=dst-png_s100x100&_nc_cat=1&ccb=1-7&_nc_sid=136b72&_nc_eui2=AeGpZ9xP7vfQEtNZSmy-med5Wt9TLzuBU1Ba31MvO4FTUCaAK06xG209jvqjoHJFwnZj8grqxZ_SdcE6Q2mhK5Fw&_nc_ohc=PBlN3lEt5FwQ7kNvgFWbu1K&_nc_ht=scontent-hkg1-1.xx&_nc_gid=ARzhuy2jx52s2mqe-HbGdJ_&oh=00_AYAWbc_jVNmi2wD7fkjee5pZ_-w6S0Q2qAFV7c8DOXqq2Q&oe=670E65FA') ,
          'created_at', c.created_at
        )
      )
      FROM `comment` c
      join `user` ur on ur.user_id = c.user_id
      left join image i on i.object_id = ur.user_id
      WHERE c.review_id = rv.review_id
      order by c.created_at desc
      limit 2
    ) AS comments,
    coalesce((select count(*) FROM `comment` l
        WHERE l.review_id = rv.review_id),0) as count_comment,
    
    -- JSON likes
    (
      SELECT JSON_ARRAYAGG(
        JSON_OBJECT(
          'like_id', sub_likes.like_id,
          'user_id', sub_likes.user_id,
          'fullname', sub_likes.fullname
        )
      )
      FROM (
        SELECT l.like_id,l.user_id, ur.fullname
        FROM `like` l
        JOIN `user` ur ON ur.user_id = l.user_id
        WHERE l.review_id = rv.review_id
		and l.user_id = p_UserId 
        UNION
        -- Lấy 2 user mới nhất
       SELECT l.like_id,l.user_id, ur.fullname
        FROM `like` l
        JOIN `user` ur ON ur.user_id = l.user_id
        WHERE l.review_id = rv.review_id
      ) AS sub_likes 
    ) AS likes,
    coalesce((select count(*) FROM `like` l
        WHERE l.review_id = rv.review_id),0) as count_like
  FROM review rv
  join book b on b.book_id = rv.book_id
  join `user` u on u.user_id = rv.user_id
  left join reviewbookuser rbu on rbu.user_id = p_UserId and rbu.book_id = rv.book_id
  left join image i1 on i1.object_id = b.book_id 
  left join image i2 on i2.object_id = u.user_id
  left join (
	  select bli.book_id,bl.list_type, bli.book_list_item_id
	  from booklist bl 
	  join booklistitem bli on bli.book_list_id = bl.book_list_id
      where bl.user_id = p_UserId
  ) as blid on blid.book_id = rv.book_id
  WHERE (p_TextSearch IS NULL
  OR b.book_name LIKE CONCAT('%', p_TextSearch, '%')
  OR b.author_name LIKE CONCAT('%', p_TextSearch, '%'));

  SET @indexFirst = p_PageNumber * p_PageSize - p_PageSize + 1;



  SET @indexLast = p_PageNumber * p_PageSize;
  
 
    
  SELECT

    *

  FROM tblOrginal do

  WHERE do.RowIndex BETWEEN @indexFirst AND @indexLast
  order by RowIndex DESC ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_UserToken_GetByToken` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_UserToken_GetByToken`(p_Token varchar(255))
BEGIN
    SELECT * FROM UserToken WHERE token = p_Token and  created_at = (SELECT MAX(created_at) FROM UserToken WHERE token = p_Token);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_User_GetByEmail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_User_GetByEmail`(p_Email nvarchar(100))
BEGIN
	select * from `user` where Email = p_Email;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_User_GetByEmailAndPassword` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_User_GetByEmailAndPassword`(p_email varchar(100),p_password varchar(100))
BEGIN
	select u.user_id,
		   u.fullname,
           u.email,
           u.phone,
           i.image_link as profile_picture,
           u.`role`
    from `user` u
    left join image i on i.object_id = u.user_id
    where email = p_email and `password` = p_password ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_User_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_User_Update`(IN p_user_id char(36), IN p_fullname varchar(100), IN p_phone varchar(50),IN p_modified_at datetime)
BEGIN

  UPDATE `user`

  SET fullname = p_fullname,

      phone = p_phone,

      modified_at = p_modified_at

  WHERE user_id = p_user_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-29 23:10:26
