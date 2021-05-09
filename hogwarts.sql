-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 09, 2021 at 04:26 AM
-- Server version: 10.1.32-MariaDB
-- PHP Version: 7.2.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hogwarts`
--

-- --------------------------------------------------------

--
-- Table structure for table `casas`
--

CREATE TABLE `casas` (
  `id_casa` int(32) NOT NULL,
  `casa` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `casas`
--

INSERT INTO `casas` (`id_casa`, `casa`) VALUES
(1, 'Gryffindor'),
(2, 'Hufflepuff'),
(3, 'Ravenclaw'),
(4, 'Slytherin'),
(5, 'Sin casa');

-- --------------------------------------------------------

--
-- Table structure for table `estados`
--

CREATE TABLE `estados` (
  `id_estado` int(32) NOT NULL,
  `estado` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `estados`
--

INSERT INTO `estados` (`id_estado`, `estado`) VALUES
(1, 'proceso_inscripcion'),
(2, 'inscripto'),
(3, 'no_inscripto'),
(4, 'inhabilitado');

-- --------------------------------------------------------

--
-- Table structure for table `solicitudes_inscripcion`
--

CREATE TABLE `solicitudes_inscripcion` (
  `id_inscripcion` int(32) NOT NULL,
  `usuario_solicitando_id` int(32) NOT NULL,
  `casa_solicitada_id` int(32) NOT NULL DEFAULT '5',
  `estado_solicitud_id` int(32) NOT NULL DEFAULT '3',
  `fecha_solicitando` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tipo_usuarios`
--

CREATE TABLE `tipo_usuarios` (
  `id_tipo_usuario` int(32) NOT NULL,
  `tipo_usuario` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipo_usuarios`
--

INSERT INTO `tipo_usuarios` (`id_tipo_usuario`, `tipo_usuario`) VALUES
(1, 'Profesor'),
(2, 'Estudiante');

-- --------------------------------------------------------

--
-- Table structure for table `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(32) NOT NULL,
  `tipo_usuario_id` int(32) NOT NULL,
  `estado_id` int(32) NOT NULL DEFAULT '3',
  `nombre` varchar(20) NOT NULL,
  `apellido` varchar(20) NOT NULL,
  `identificacion` int(10) NOT NULL DEFAULT '0',
  `edad` int(2) NOT NULL DEFAULT '0',
  `sexo` enum('hombre','mujer') NOT NULL,
  `casa_id` int(32) NOT NULL DEFAULT '5',
  `fecha_registro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `casas`
--
ALTER TABLE `casas`
  ADD PRIMARY KEY (`id_casa`);

--
-- Indexes for table `estados`
--
ALTER TABLE `estados`
  ADD PRIMARY KEY (`id_estado`);

--
-- Indexes for table `solicitudes_inscripcion`
--
ALTER TABLE `solicitudes_inscripcion`
  ADD PRIMARY KEY (`id_inscripcion`) USING BTREE,
  ADD KEY `fk_usuario_solicitando` (`usuario_solicitando_id`) USING BTREE,
  ADD KEY `fk_casa_solicitada` (`casa_solicitada_id`) USING BTREE,
  ADD KEY `fk_estado_solicitud` (`estado_solicitud_id`) USING BTREE;

--
-- Indexes for table `tipo_usuarios`
--
ALTER TABLE `tipo_usuarios`
  ADD PRIMARY KEY (`id_tipo_usuario`);

--
-- Indexes for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`),
  ADD KEY `fk_tipo_usuario` (`tipo_usuario_id`),
  ADD KEY `fk_estado` (`estado_id`),
  ADD KEY `fk_casa` (`casa_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `casas`
--
ALTER TABLE `casas`
  MODIFY `id_casa` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `estados`
--
ALTER TABLE `estados`
  MODIFY `id_estado` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `solicitudes_inscripcion`
--
ALTER TABLE `solicitudes_inscripcion`
  MODIFY `id_inscripcion` int(32) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tipo_usuarios`
--
ALTER TABLE `tipo_usuarios`
  MODIFY `id_tipo_usuario` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(32) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `solicitudes_inscripcion`
--
ALTER TABLE `solicitudes_inscripcion`
  ADD CONSTRAINT `fk_casa_solicitada` FOREIGN KEY (`casa_solicitada_id`) REFERENCES `casas` (`id_casa`),
  ADD CONSTRAINT `fk_estado_solicitud` FOREIGN KEY (`estado_solicitud_id`) REFERENCES `estados` (`id_estado`),
  ADD CONSTRAINT `fk_usuario_solicitando` FOREIGN KEY (`usuario_solicitando_id`) REFERENCES `usuarios` (`id_usuario`);

--
-- Constraints for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `fk_casa` FOREIGN KEY (`casa_id`) REFERENCES `casas` (`id_casa`),
  ADD CONSTRAINT `fk_estado` FOREIGN KEY (`estado_id`) REFERENCES `estados` (`id_estado`),
  ADD CONSTRAINT `fk_tipo_usuario` FOREIGN KEY (`tipo_usuario_id`) REFERENCES `tipo_usuarios` (`id_tipo_usuario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
