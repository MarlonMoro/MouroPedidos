-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 29-Mar-2018 às 12:16
-- Versão do servidor: 10.1.28-MariaDB
-- PHP Version: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mouropedido`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `pedido`
--

CREATE TABLE `pedido` (
  `idpedido` int(11) NOT NULL,
  `dataEntrega` varchar(20) NOT NULL,
  `horaEntrega` varchar(45) NOT NULL,
  `tipoPedido` int(11) NOT NULL,
  `nomeCliente` varchar(100) NOT NULL,
  `telefoneCliente` varchar(45) DEFAULT NULL,
  `enderecoCliente` varchar(100) DEFAULT NULL,
  `itensPedido` varchar(255) NOT NULL,
  `formaPagamento` int(11) NOT NULL,
  `observacoes` varchar(45) DEFAULT NULL,
  `dataPedido` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `pedido`
--

INSERT INTO `pedido` (`idpedido`, `dataEntrega`, `horaEntrega`, `tipoPedido`, `nomeCliente`, `telefoneCliente`, `enderecoCliente`, `itensPedido`, `formaPagamento`, `observacoes`, `dataPedido`) VALUES
(8, '08/03/2018', '20:00', 1, 'Marlon MOro', '3421 6363', 'Av. brasilia 2335', '1 bolo\r\n2 coca\r\n3 agua', 0, '', '2018-03-08 18:03:51'),
(9, '08/03/2018', '20:00', 1, 'Joao Moro', '3421 6363', 'Av. brasilia 2335', '1 bolo\r\n2 coca\r\n3 agua', 0, '', '2018-03-08 18:04:09'),
(10, '08/03/2018', '20:00', 0, 'Fabio', '34212020', 'brasilia 2020', '1 coca', 1, '', '2018-03-08 18:07:37'),
(11, '08/03/2018', '20:00', 0, 'Fabiono', '9999999', 'minas gerais 1010', '2 bolo', 1, '', '2018-03-08 18:08:06'),
(12, '26/02/2018', '21:19', 1, 'Teste Preenche', '34236100', 'av. brasil 200', '1 coca \r\n2 cotuba\r\n3 poty', 1, ' ', '2018-03-13 22:13:04');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pedido`
--
ALTER TABLE `pedido`
  ADD PRIMARY KEY (`idpedido`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pedido`
--
ALTER TABLE `pedido`
  MODIFY `idpedido` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
