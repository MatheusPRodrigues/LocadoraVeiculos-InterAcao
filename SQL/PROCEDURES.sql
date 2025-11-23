USE LocadoraBD;
GO

CREATE OR ALTER PROCEDURE sp_AdicionarLocacao @LocacaoID CHAR(36),
                                              @ClienteIdLocacao INT,
                                              @VeiculoIdLocacao INT,
                                              @DataDevolucaoPrevistaLocacao DATETIME,
                                              @DataDevolucaoRealLocacao DATETIME NULL,
                                              @ValorDiariaLocacao DECIMAL(10, 2),
                                              @ValorTotalLocacao DECIMAL(10, 2),
                                              @MultaLocacao DECIMAL(10, 2) NULL,
                                              @StatusLocacao VARCHAR(20) NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO tblLocacoes (LocacaoID, ClienteID, VeiculoID, DataDevolucaoPrevista, DataDevolucaoReal, ValorDiaria,
                                 ValorTotal, Multa, Status)
        VALUES (@LocacaoID, @ClienteIdLocacao, @VeiculoIdLocacao, @DataDevolucaoPrevistaLocacao,
                @DataDevolucaoRealLocacao, @ValorDiariaLocacao,
                @ValorTotalLocacao, @MultaLocacao, @StatusLocacao);

        PRINT 'Locacao adicionada com sucesso!'
    END TRY
    BEGIN CATCH
        PRINT 'Erro ao adicionar locacao' + ERROR_MESSAGE();
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_AtualizarLocacao @idLocacao CHAR(36),
                                              @DataDevolucaoReal DATETIME,
                                              @Status VARCHAR(20),
                                              @Multa DECIMAL(10, 2)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        UPDATE tblLocacoes
        SET DataDevolucaoReal = @DataDevolucaoReal,
            Status            = @Status,
            Multa             = @Multa
        WHERE LocacaoID = @idLocacao;

        PRINT 'Locacao Atualizada com sucesso!'
    END TRY
    BEGIN CATCH
        PRINT 'Erro ao atualizar localizacao: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_BuscarLocacaoId @idLocacao CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SELECT LocacaoID,
               c.Nome,
               v.Modelo,
               DataLocacao,
               DataDevolucaoPrevista,
               DataDevolucaoReal,
               ValorDiaria,
               ValorTotal,
               Multa,
               Status
        FROM tblLocacoes l
        JOIN tblClientes c
        ON c.ClienteID = l.ClienteID
        JOIN tblVeiculos v
        ON v.VeiculoID = l.VeiculoID
        WHERE LocacaoID = @idLocacao;
    END TRY
    BEGIN CATCH
        PRINT 'Erro ao encontrar locacao: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_BuscarLocacao
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SELECT LocacaoID,
               c.Nome,
               v.Modelo,
               DataLocacao,
               DataDevolucaoPrevista,
               DataDevolucaoReal,
               ValorDiaria,
               ValorTotal,
               Multa,
               Status
        FROM tblLocacoes l
        JOIN tblClientes c
        ON c.ClienteID = l.ClienteID
        JOIN tblVeiculos v
        ON v.VeiculoID = l.VeiculoID
    END TRY
    BEGIN CATCH
        PRINT 'Erro ao encontrar locacao: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_CancelarLocacao @idLocacao CHAR(36),
                                             @Status VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE tblLocacoes
        SET Status = @Status
        WHERE LocacaoID = @idLocacao;
        
        PRINT 'Locacao Atualizada';
    END TRY
    BEGIN CATCH
        PRINT 'Erro ao atualizar locacao: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END
GO