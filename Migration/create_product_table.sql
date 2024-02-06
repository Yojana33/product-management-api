CREATE TABLE product(
    id VARCHAR(30) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    price NUMERIC NOT NULL,
    quantity INTEGER NOT NULL,
    category_id VARCHAR(30) REFERENCES category(id),
    is_active BOOLEAN NOT NULL,
    created_at TIMESTAMP,
    updated_at TIMESTAMP,
    deleted_at TIMESTAMP

);