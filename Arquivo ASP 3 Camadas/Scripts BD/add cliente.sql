create proc [dbo].[sp_cliente_adc](
@codigo varchar(5),
@nome varchar(50),
@endereco varchar(50),
@telefone varchar(20),
@cpf varchar(8)
)
as
insert into cliente values(@codigo,@nome,@endereco,@telefone,@cpf)

GO