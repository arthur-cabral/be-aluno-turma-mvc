﻿namespace DesafioTecnicoAlunoTurma.Commons
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
