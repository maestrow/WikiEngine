DECLARE @name nvarchar(255)
DECLARE @file_stream varbinary(max)
DECLARE @parentpath nvarchar(4000)
DECLARE @is_hidden bit
DECLARE @is_readonly bit
DECLARE @is_archive bit
DECLARE @is_system bit
DECLARE @is_temporary bit

-- TODO: Set parameter values here.

SELECT @parentpath=null, @is_hidden=0, @is_readonly=0, @is_archive=0, @is_system=0, @is_temporary=0

{statements}