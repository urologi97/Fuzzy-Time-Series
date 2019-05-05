-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 11, 2017 at 08:03 PM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 7.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `suhu`
--

-- --------------------------------------------------------

--
-- Table structure for table `suhu2`
--

CREATE TABLE `suhu2` (
  `id` int(4) NOT NULL,
  `tahun` int(11) NOT NULL,
  `bulan` int(11) NOT NULL,
  `suhu` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `suhu2`
--

INSERT INTO `suhu2` (`id`, `tahun`, `bulan`, `suhu`) VALUES
(1, 2003, 1, 23.47),
(2, 2003, 1, 23.83),
(3, 2003, 2, 23.6),
(4, 2003, 2, 24.15),
(5, 2003, 3, 23.53),
(6, 2003, 3, 24.13),
(7, 2003, 4, 24.06),
(8, 2003, 4, 24.37),
(9, 2003, 5, 24.15),
(10, 2003, 5, 23.15),
(11, 2003, 6, 23.04),
(12, 2003, 6, 23.94),
(13, 2003, 7, 21.39),
(14, 2003, 7, 21.96),
(15, 2003, 8, 21.69),
(16, 2003, 8, 22.33),
(17, 2003, 9, 22.63),
(18, 2003, 9, 23.77),
(19, 2003, 10, 24),
(20, 2003, 10, 24.19),
(21, 2003, 11, 23.88),
(22, 2003, 11, 23.61),
(23, 2003, 12, 23.88),
(24, 2003, 12, 23.1),
(25, 2004, 1, 23.78),
(26, 2004, 1, 23.77),
(27, 2004, 2, 23.53),
(28, 2004, 2, 24.03),
(29, 2004, 3, 23.39),
(30, 2004, 3, 23.17),
(31, 2004, 4, 23.79),
(32, 2004, 4, 23.36),
(33, 2004, 5, 24.34),
(34, 2004, 5, 23.99),
(35, 2004, 6, 22.4),
(36, 2004, 6, 22.71),
(37, 2004, 7, 22.61),
(38, 2004, 7, 22.54),
(39, 2004, 8, 21.72),
(40, 2004, 8, 21.86),
(41, 2004, 9, 22.52),
(42, 2004, 9, 23.27),
(43, 2004, 10, 23.53),
(44, 2004, 10, 24.14),
(45, 2004, 11, 25.65),
(46, 2004, 11, 25.05),
(47, 2004, 12, 23.35),
(48, 2004, 12, 24.56);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `suhu2`
--
ALTER TABLE `suhu2`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `suhu2`
--
ALTER TABLE `suhu2`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
