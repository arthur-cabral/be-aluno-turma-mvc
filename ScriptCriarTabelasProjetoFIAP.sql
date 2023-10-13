create table aluno (
	id int primary key identity(1,1),
	nome varchar(255),
	usuario varchar(45),
	senha varchar(60),
	ativo bit
);

create table turma (
	id int primary key identity(1,1),
	nome_turma varchar(45) unique,
	ano int,
	ativo bit
);

create table aluno_turma (
	id int primary key identity(1,1),
	aluno_id int,
	turma_id int,
	ativo bit,
	foreign key (aluno_id) references aluno(id),
	foreign key (turma_id) references turma(id)
);