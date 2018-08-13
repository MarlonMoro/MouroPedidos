-- MySQL Script generated by MySQL Workbench
-- Mon Jan  1 19:47:35 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mouroPedido
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mouroPedido
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mouroPedido` DEFAULT CHARACTER SET utf8 ;
USE `mouroPedido` ;

-- -----------------------------------------------------
-- Table `mouroPedido`.`pedido`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mouroPedido`.`pedido` ;

CREATE TABLE IF NOT EXISTS `mouroPedido`.`pedido` (
  `idpedido` INT NOT NULL AUTO_INCREMENT,
  `nomeCliente` VARCHAR(45) NOT NULL,
  `horaEntrega` DATETIME NOT NULL,
  `telefoneCliente` VARCHAR(45) NULL,
  `enderecoEntrega` VARCHAR(45) NULL,
  `tipoPedido` INT NULL,
  `dataPedido` DATETIME NOT NULL,
  `itensPedido` VARCHAR(255) NOT NULL,
  `formaPagamento` VARCHAR(45) NOT NULL,
  `observacao` VARCHAR(100) NULL,
  PRIMARY KEY (`idpedido`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
