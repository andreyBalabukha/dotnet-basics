/-- Task #1

CREATE TABLE person (
	id BIGSERIAL PRIMARY KEY,
	firstName VARCHAR(50) NOT NULL,
	lastName VARCHAR(50) NOT NULL
);

CREATE TABLE address (
	id BIGSERIAL PRIMARY KEY,
	street VARCHAR(50) NOT NULL,
	city VARCHAR(20),
	state VARCHAR(50),
	zipCode VARCHAR(50)
);

CREATE TABLE employee (
	id BIGSERIAL PRIMARY KEY,
	addressId BIGSERIAL NOT NULL REFERENCES address(id),
    personId BIGSERIAL NOT NULL REFERENCES person(id),
    companyName VARCHAR(20) NOT NULL,
    position VARCHAR(30) NOT NULL,
    employeeName VARCHAR(100)
);

CREATE TABLE company (
	id BIGSERIAL PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    addressId BIGSERIAL NOT NULL REFERENCES address(id)
);


INSERT INTO person (firstName, lastName) VALUES ('Name_1', 'Surname_1');
INSERT INTO person (firstName, lastName) VALUES ('Name_2', 'Surname_2');
INSERT INTO person (firstName, lastName) VALUES ('Name_3', 'Surname_3');

INSERT INTO address (street, city, state, zipCode) VALUES ('street_1', 'city_1', 'state_1', 'zipCode_1');
INSERT INTO address (street, city, state, zipCode) VALUES ('street_2', 'city_2', 'state_2', 'zipCode_2');
INSERT INTO address (street, city, state, zipCode) VALUES ('street_3', 'city_3', 'state_3', 'zipCode_3');

INSERT INTO employee (addressId, personId, companyName, position, employeeName) VALUES (1, 1, 'company_1', 'position_1', 'employeeName_1');
INSERT INTO employee (addressId, personId, companyName, position, employeeName) VALUES (2, 2, 'company_2', 'position_2', 'employeeName_2');
INSERT INTO employee (addressId, personId, companyName, position, employeeName) VALUES (3, 3, 'company_3', 'position_3', 'employeeName_3');

INSERT INTO company (name, addressId) VALUES ('company_1', 1);
INSERT INTO company (name, addressId) VALUES ('company_2', 2);
INSERT INTO company (name, addressId) VALUES ('company_3', 3);

/-- Task #2

CREATE VIEW EmployeeInfo AS
SELECT employee.id AS EmployeeId,
COALESCE(employee.employeeName, CONCAT(person.firstName, ' ', person.lastName)) AS EmployeeFullName,
CONCAT(address.zipCode, '-', address.state, ', ', address.city, '-', address.street) AS EmployeeFullAddress,
CONCAT(company.name, ' (', employee.position, ')') AS EmployeeCompanyInfo
FROM employee
JOIN person ON employee.personId = person.id
JOIN address ON employee.addressId = address.id
ORDERED BY employee.companyName ASC, address.city ASC;

/-- Task #3

CREATE OR REPLACE PROCEDURE EMPLOYEE_INFO_PROCEDURE(
    IN EmployeeName VARCHAR(100),
    IN FirstName VARCHAR(50),
    IN LastName VARCHAR(50),
    IN CompanyName VARCHAR(20),
    IN Position VARCHAR(30),
    IN Street VARCHAR(50),
    IN City VARCHAR(20),
    IN State VARCHAR(50),
    IN ZipCode VARCHAR(50)
) 
BEGIN
    IF (EmployeeName IS NULL) AND (FirstName IS NULL) AND (LastName IS NULL)
    THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'error, cannot be empty';
    END IF;

    DECLARE addressId BIGINT;
    SELECT id INTO addressId FROM address WHERE street = Street AND city = City AND state = State AND zipCode = ZipCode;

    IF addressId IS NULL
    THEN
        INSERT INTO address (street, city, state, zipCode) VALUES (Street, City, State, ZipCode);
        SELECT id INTO addressId FROM address WHERE street = Street AND city = City AND state = State AND zipCode = ZipCode;
    ELSE
        UPDATE address SET street = Street, city = City, state = State, zipCode = ZipCode WHERE address.id = addressId;
    END IF;

    DECLARE personId BIGINT;
    SELECT id INTO personId FROM person WHERE firstName = FirstName AND lastName = LastName;

    IF personId IS NULL
    THEN
        INSERT INTO person (firstName, lastName) VALUES (FirstName, LastName);
        SELECT id INTO personId FROM person WHERE firstName = FirstName AND lastName = LastName;
    ELSE
        UPDATE person SET firstName = FirstName, lastName = LastName WHERE person.id = personId;
    END IF;

    DECLARE companyId BIGINT;
    SELECT id INTO companyId FROM company WHERE name = CompanyName;

END;


