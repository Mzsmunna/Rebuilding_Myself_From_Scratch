using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public enum SqlKeywords
    {
        USE,
        CREATE, 
        UPDATE,
        DROP,
        DELETE,
        PRIMARY,
        KEY,
        TABLE,
        SELECT,
        FROM,
        WHERE,
        NOT,
        NULL,
        MAX,
        IDENTITY, // IDENTITY(1,1)
        INT,
        NVARCHAR, // NVARCHAR(4000), NVARCHAR(MAX)
        VARCHAR, // VARCHAR(255)
        DATE,
        DATETIME,
    }
}
