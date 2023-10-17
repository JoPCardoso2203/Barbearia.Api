CREATE DATABASE barbearia;

USE barbearia;

-- barbearia.usuario definition

CREATE TABLE `usuario` (
  `USUA_ID` int(11) NOT NULL AUTO_INCREMENT,
  `USUA_NOME` varchar(100) NOT NULL,
  `USUA_EMAIL` varchar(150) NOT NULL,
  `USUA_SENHA` varchar(50) NOT NULL,
  `USUA_CPF` varchar(11) NOT NULL,
  `USUA_TIPO_ACESSO` enum('cliente','barbearia') NOT NULL,
  `USUA_DT_CRIACAO` datetime NOT NULL,
  PRIMARY KEY (`USUA_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- barbearia.habilidade_funcionario definition

CREATE TABLE `funcionario` (
  `FUNC_ID` int(11) NOT NULL AUTO_INCREMENT,
  `FUNC_NOME` varchar(50) DEFAULT NULL,
  `FUNC_TELEFONE` varchar(50) DEFAULT NULL,
  `FUNC_DT_CRIACAO` datetime NOT NULL,
  PRIMARY KEY (`FUNC_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- barbearia.agendamento definition

CREATE TABLE `agendamento` (
  `AGEN_ID` int(11) NOT NULL AUTO_INCREMENT,
  `AGEN_SERV_ID` int(11) DEFAULT NULL,
  `AGEN_USUA_ID` int(11) DEFAULT NULL,
  `AGEN_DT_INICIO` datetime NOT NULL,
  `AGEN_DT_CRIACAO` datetime DEFAULT NULL,
  PRIMARY KEY (`AGEN_ID`),
  KEY `AGEN_FUNC_ID` (`AGEN_FUNC_ID`),
  KEY `AGEN_USUA_ID` (`AGEN_USUA_ID`),
  CONSTRAINT `agendamento_ibfk_1` FOREIGN KEY (`AGEN_FUNC_ID`) REFERENCES `funcionario` (`FUNC_ID`),
  CONSTRAINT `agendamento_ibfk_2` FOREIGN KEY (`AGEN_USUA_ID`) REFERENCES `usuario` (`USUA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- barbearia.transacao definition

CREATE TABLE `transacao` (
  `TRANS_ID` int(11) NOT NULL AUTO_INCREMENT,
  `TRANS_AGEN_ID` int(11) DEFAULT NULL,
  `TRANS_DT_PAGAMENTO` datetime NOT NULL,
  `TRANS_DT_REEMBOLSO` datetime DEFAULT NULL,
  `TRANS_FORMA_PAGAMENTO` enum('debito','credito','boleto','pix','local') NOT NULL,
  `TRANS_STATUS` enum('aceito','recusado','cancelado') NOT NULL,
  PRIMARY KEY (`TRANS_ID`),
  KEY `TRANS_AGEN_ID` (`TRANS_AGEN_ID`),
  CONSTRAINT `transacao_ibfk_1` FOREIGN KEY (`TRANS_AGEN_ID`) REFERENCES `agendamento` (`AGEN_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;