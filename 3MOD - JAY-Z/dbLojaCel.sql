create database dbLojaCel;
use dbLojaCel;

create table tbLogin (
usuario varchar(50) primary key not null,
senha varchar(30) not null,
tipo int
);

-- Tipo 1: Cliente
-- Tipo 2: Adm

create table tbCliente(
CodCli int primary key auto_increment,
NomeCli varchar(50) not null,
CpfCli varchar(14)  not null,
DataNascCli varchar(15) not null,
SexoCli varchar(10) not null, -- poder somente selecionar masculino ou feminino
EnderecoCli varchar(50) not null,
NumeroCasaCli varchar (10) not null,
CepCli varchar(9) not null,
NmBairro varchar(20) not null,
NmEstado varchar (20) not null,
EmailCli varchar(50)  not null,
CelularCli varchar(24),
TelefoneCli varchar(24),
usuario varchar(50) not null references tbLogin(usuario) 
);



create table tbPagamento(
CodPagto int primary key auto_increment,
NomeCartao varchar(100),
NumeroCartao varchar(25),
DtExpiracao varchar(15),
Cvv varchar(3),
CodCarrinho int references tbCarrinho(CodCarrinho)
);

create table tbCarrinho(
CodCarrinho int primary key auto_increment,
DataCarrinho varchar(10),
HoraCarrinho varchar(10),
VlCompra varchar(50) not null,
CodCli int,
CONSTRAINT foreign key(CodCli) references tbCliente(CodCli)
);

create table tbTipoProduto(
CodTipoProduto int primary key auto_increment,
NmTipoProduto varchar(80) not null
);

create table tbProduto(
CodProd int primary key auto_increment,
NmProd varchar(80) not null,
DescricaoProd varchar(600),
VlProd varchar(50) not null,
MarcaProd varchar(50),
EstoqueProd int,
ImagemProd varchar(255),
CodTipoProduto int,
foreign key(CodTipoProduto) references tbTipoProduto(CodTipoProduto)
);

create table tbItensCarrinho(
CodItensCarrinho int primary key auto_increment,
CodCarrinho int,
CodProd int,
VlTotal varchar(50),
Qtitens int,
foreign key(CodProd) references tbProduto(CodProd),
foreign key(CodCarrinho) references tbCarrinho(CodCarrinho)
);

create table tbContato(
CodContato int primary key auto_increment,
NomeContato varchar(100) not null,
EmailContato varchar(100) not null,
NumeroContato varchar(20) not null,
MensagemContato varchar (1000) not null
);


create view vwCliente -- troquei paciente por cliente 
as select
	tbCliente.CodCli,
	tbLogin.usuario,
	tbCliente.NomeCli,
    tbCliente.CpfCli,
    tbCliente.DataNascCli,
    tbCliente.SexoCli,
    tbCliente.EnderecoCli ,
    tbCliente.NumeroCasaCli,
    tbCliente.CepCli,
    tbCliente.NmBairro,
    tbCliente.NmEstado,
    tbCliente.EmailCli,
    tbCliente.CelularCli,
    tbCliente.TelefoneCli
from
	tbCliente
inner join tbLogin on tbLogin.usuario = tbCliente.usuario;

-- create view vwCarrinho
-- as select
-- tbCarrinho.CodCarrinho,
-- tbCarrinho.DataCarrinho,
-- tbCarrinho.HoraCarrinho,
-- tbCarrinho.VlCompra,
-- tbCarrinho.CodCli,
-- tbCarrinho.CodPagto
-- from 
-- tbCarrinho;

create view vwProduto
as select
	tbProduto.CodProd,
    tbProduto.NmProd,
    tbProduto.DescricaoProd,
    tbProduto.VlProd,
    tbProduto.MarcaProd,
    tbProduto.EstoqueProd,
    tbProduto.ImagemProd,
    tbTipoProduto.NmTipoProduto
from
	tbProduto
inner join tbTipoProduto on tbTipoProduto.CodTipoProduto = tbProduto.CodTipoProduto;



select * from tbLogin;
select * from tbCliente;
select * from tbPagamento;
select * from tbCarrinho;
select * from tbTipoProduto;
select * from tbProduto;
select * from tbItensCarrinho;
select * from tbContato;

select * from vwCliente;
select * from vwCarrinho;
select * from vwProduto;

drop table tbPagamento;
-- referencias usadas bdOdonto e bdvenda (rovilson) e db_Loja1710 (Andre)
	