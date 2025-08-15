[[NoSQL]] databases, also known as "not only SQL" or non-relational databases, are a category of database management systems that store and retrieve data in ways other than the tabular relations used by traditional relational databases ([SQL Database](../SQL/SQL Database)). They were developed to address the scalability and flexibility challenges encountered by relational databases when dealing with large volumes of rapidly changing, unstructured, or semi-structured data, particularly in modern web applications and big data environments.

Key characteristics and types of [[NoSQL Database]] include:

- **Flexible Schema:**
    
    Unlike SQL databases that require a predefined schema and data to fit into rigid tables, NoSQL databases offer flexible schemas, allowing for diverse data structures within the same collection. This adaptability is particularly useful for handling unstructured data like documents, images, and audio files.
    
- **Horizontal Scaling:**
    
    NoSQL databases are designed for horizontal scaling, meaning they can distribute data across multiple servers or nodes, allowing for increased capacity and performance by adding more commodity hardware rather than upgrading a single powerful server.
    
- **Various Data Models:**
    
    NoSQL databases employ different data models to suit various use cases:
    
    - **Document Databases:** Store data in flexible, semi-structured documents (e.g., [[JSON]], [[BSON]], [[XML]]), often used for content management, catalogs, and user profiles. Examples include [[MongoDB]] and  [[CouchDB]].
    - **Key-Value Stores:** Store data as simple key-value pairs, offering high performance for simple data retrieval. Examples include Redis and [[Amazon DynamoDB]].
    - **Wide-Column Stores:** Organize data into tables with rows and dynamically defined columns, ideal for handling large datasets with sparse data. Examples include [[Cassandra]] and [[HBase]].
    - **Graph Databases:** Represent data as nodes and edges, emphasizing relationships between data points, suitable for social networks, recommendation engines, and fraud detection. Examples include Neo4j and Amazon Neptune.
    
- **Eventual Consistency:**
    
    Many distributed NoSQL databases prioritize availability and partition tolerance over strong consistency, meaning data might not be immediately consistent across all replicas after a write operation. This trade-off is often acceptable for applications where real-time consistency is not paramount.
    

NoSQL databases are well-suited for applications requiring high scalability, flexibility, and the ability to handle diverse data types, such as real-time analytics, mobile applications, IoT data, and content management systems.