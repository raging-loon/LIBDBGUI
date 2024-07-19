create database if not exists library;

SET sql_safe_updates = 0;

use library;
-- drop table if exists out_books;
-- drop table if exists _client;
-- drop table if exists books;
CREATE TABLE IF NOT EXISTS _client
(
	client_id INT PRIMARY KEY AUTO_INCREMENT,
    c_is_student BOOL,
    client_fines DECIMAL(4,2),
    client_num_books INT,
    client_name VARCHAR(100)
);
CREATE TABLE IF NOT EXISTS books
(
	book_id INT PRIMARY KEY AUTO_INCREMENT,
    book_isbn VARCHAR(11) UNIQUE,
    book_name VARCHAR(256),
    book_author VARCHAR(256),
    genre VARCHAR(64),
    publish_date DATE,
    num_copies INT,
    num_copies_out INT
);

CREATE TABLE IF NOT EXISTS out_books
(
	out_book_id INT PRIMARY KEY AUTO_INCREMENT,
    check_out_date DATE,
    book_id INT,
    client_id INT,
    FOREIGN KEY (book_id) REFERENCES books(book_id),
	FOREIGN KEY (client_id) REFERENCES _client(client_id)
);


DROP PROCEDURE IF EXISTS InternalCheckout;
DELIMITER $$
CREATE PROCEDURE
InternalCheckout(_client_id INT, _book_isbn TEXT)
BEGIN
	-- add to list of checked out booksnum_
    DECLARE _book_id INT;
    
    SELECT book_id
    INTO _book_id
    FROM books
    WHERE book_isbn = _book_isbn
    LIMIT 1;
    
    
    UPDATE books 
    SET num_copies_out = num_copies_out + 1
    WHERE book_isbn = _book_isbn;

    INSERT INTO out_books (check_out_date, book_id, client_id)
    VALUES
    (NOW(), _book_id, _client_id);
    
    UPDATE _client 
    SET client_num_books = client_num_books + 1
    WHERE client_id = _client_id;

END$$
DELIMITER ;

-- The management app will check that
-- The book has copies out
DROP PROCEDURE IF EXISTS InternalReturn;
DELIMITER $$

CREATE PROCEDURE
InternalReturn(_client_id INT, _book_isbn TEXT)
BEGIN
	DECLARE _book_id INT;
    
    SELECT book_id
    INTO _book_id
    FROM books
    WHERE book_isbn = _book_isbn
    LIMIT 1;
    
    DELETE FROM out_books
    WHERE (client_id = _client_id AND book_id = _book_id)
    LIMIT 1;
    
    UPDATE _client
    SET client_num_books = client_num_books - 1
    WHERE client_id = _client_id;
    
    UPDATE books 
    SET num_copies_out = num_copies_out - 1
    WHERE book_id = _book_id;


END$$
DELIMITER ;


