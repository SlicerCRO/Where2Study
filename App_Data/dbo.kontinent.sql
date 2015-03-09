CREATE TABLE [dbo].[kontinent] (
    [id] INT IDENTITY (1, 1) NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'w2s.kontinent', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'kontinent';

