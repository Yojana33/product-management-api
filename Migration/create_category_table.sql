CREATE TABLE category(
    id VARCHAR(30) PRIMARY KEY,
    name VARCHAR(50),
    is_active BOOLEAN NOT NULL,
    created_at TIMESTAMP,
    updated_at TIMESTAMP,
    deleted_at TIMESTAMP

);