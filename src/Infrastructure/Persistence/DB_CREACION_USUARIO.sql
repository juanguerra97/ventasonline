DROP DATABASE IF EXISTS ventasonlineumg;

CREATE DATABASE ventasonlineumg;

USE ventasonlineumg;

DROP USER IF EXISTS umgadmin;

CREATE USER 'umgadmin'@'%' IDENTIFIED BY 'UmgAdmin$123';

GRANT ALL PRIVILEGES ON ventasonlineumg.* TO 'umgadmin'@'%';