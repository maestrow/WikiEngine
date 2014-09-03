SELECT @name='{name}', @file_stream=convert(varbinary(max), '{content}')
EXECUTE [dbo].[File_CreateFile] @name, @file_stream, @parentpath, @is_hidden, @is_readonly, @is_archive, @is_system, @is_temporary

