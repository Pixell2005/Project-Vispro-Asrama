-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 04, 2024 at 07:50 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_asrama`
--

-- --------------------------------------------------------

--
-- Table structure for table `asrama`
--

CREATE TABLE `asrama` (
  `nama_asrama` enum('Jasmine','Annex','Edelweis','Crystal') NOT NULL,
  `harga_asrama` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `asrama`
--

INSERT INTO `asrama` (`nama_asrama`, `harga_asrama`) VALUES
('Jasmine', 15000000),
('Annex', 10000000),
('Edelweis', 9000000),
('Crystal', 8500000);

-- --------------------------------------------------------

--
-- Table structure for table `asrama_boys`
--

CREATE TABLE `asrama_boys` (
  `nama_asrama` varchar(20) NOT NULL,
  `harga_asrama` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `asrama_boys`
--

INSERT INTO `asrama_boys` (`nama_asrama`, `harga_asrama`) VALUES
('Crystal', 8500000);

-- --------------------------------------------------------

--
-- Table structure for table `asrama_girls`
--

CREATE TABLE `asrama_girls` (
  `nama_asrama` enum('Jasmine','Annex','Edelweis','Crystal') NOT NULL,
  `harga_asrama` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `asrama_girls`
--

INSERT INTO `asrama_girls` (`nama_asrama`, `harga_asrama`) VALUES
('Jasmine', 15000000),
('Annex', 10000000),
('Edelweis', 9000000);

-- --------------------------------------------------------

--
-- Table structure for table `booking`
--

CREATE TABLE `booking` (
  `nama` varchar(32) NOT NULL,
  `nim` int(20) NOT NULL,
  `asrama` enum('Jasmine','Annex','Edelweis','Crystal','Genset') NOT NULL,
  `no_kamar` int(11) NOT NULL,
  `balance` decimal(10,0) NOT NULL,
  `gender` enum('male','female') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `dormitory_head`
--

CREATE TABLE `dormitory_head` (
  `warden_id` int(11) NOT NULL,
  `first_name` varchar(20) NOT NULL,
  `last_name` varchar(20) NOT NULL,
  `phone_number` int(15) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `assigned_dormitory` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dormitory_head`
--

INSERT INTO `dormitory_head` (`warden_id`, `first_name`, `last_name`, `phone_number`, `email`, `password`, `assigned_dormitory`) VALUES
(1, 'jere', 'miah', 822313433, 'jere@gmail.com', 'miah', 'jasmine');

-- --------------------------------------------------------

--
-- Table structure for table `monitor`
--

CREATE TABLE `monitor` (
  `monitor_id` int(11) NOT NULL,
  `first_name` varchar(20) NOT NULL,
  `last_name` varchar(20) NOT NULL,
  `phone_number` int(15) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `monitor`
--

INSERT INTO `monitor` (`monitor_id`, `first_name`, `last_name`, `phone_number`, `email`, `password`) VALUES
(1, 'pixel', 'll', 882123, 'pixel@gmail.com', 'pixel');

-- --------------------------------------------------------

--
-- Table structure for table `pemeriksaan`
--

CREATE TABLE `pemeriksaan` (
  `tanggal_pemeriksaan` date NOT NULL,
  `no_kamar` int(11) NOT NULL,
  `jumlah_tidak_hadir` int(11) NOT NULL,
  `jumlah_hadir` int(11) NOT NULL,
  `jam_pemeriksaan` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pemeriksaan`
--

INSERT INTO `pemeriksaan` (`tanggal_pemeriksaan`, `no_kamar`, `jumlah_tidak_hadir`, `jumlah_hadir`, `jam_pemeriksaan`) VALUES
('2024-10-30', 21, 1, 1, '00:00:01');

-- --------------------------------------------------------

--
-- Table structure for table `student_asrama`
--

CREATE TABLE `student_asrama` (
  `NIM` int(15) NOT NULL,
  `full_name` varchar(32) NOT NULL,
  `asrama` varchar(50) NOT NULL,
  `room_number` int(11) NOT NULL,
  `check_in` date NOT NULL,
  `check_out` date NOT NULL,
  `jumlah_pelanggaran` int(11) NOT NULL,
  `jenis_pelanggaran` varchar(50) NOT NULL,
  `poin` int(4) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` text NOT NULL,
  `terbayar` decimal(10,0) NOT NULL,
  `sisa_bayar` decimal(10,0) NOT NULL,
  `foto` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student_asrama`
--

INSERT INTO `student_asrama` (`NIM`, `full_name`, `asrama`, `room_number`, `check_in`, `check_out`, `jumlah_pelanggaran`, `jenis_pelanggaran`, `poin`, `email`, `password`, `terbayar`, `sisa_bayar`, `foto`) VALUES
(111, 'fff', 'Crystal', 1, '0000-00-00', '0000-00-00', 0, '', 0, '111@student.unklab.ac.id', 'studentunklab2024', 0, 8500000, ''),
(444, 'dede', 'Jasmine', 2, '0000-00-00', '0000-00-00', 0, '', 0, '444@student.unklab.ac.id', 'studentunklab2024', 0, 15000000, ''),
(99, 'jiji', 'Jasmine', 9, '2024-10-31', '0000-00-00', 0, '', 0, '99@student.unklab.ac.id', 'studentunklab2024', 0, 15000000, '');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
