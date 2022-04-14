CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS follows(
  id INT AUTO_INCREMENT primary key,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  follower VARCHAR(255) NOT NULL,
  following VARCHAR(255) NOT NULL,
  FOREIGN KEY (follower) REFERENCES accounts (id) ON DELETE CASCADE,
  FOREIGN KEY (following) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
ALTER Table
  accounts
MODIFY
  COLUMN likes TEXT;
SELECT
  *
FROM
  accounts;
DELETE FROM
  accounts
WHERE
  id = "9";
UPDATE
  accounts
SET
  picture = "https://cdn.computerhoy.com/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2021/08/naruto-naruto-uzumaki-2425679.jpg"
WHERE
  id = "1";
INSERT INTO
  accounts (name, picture, id, likes)
VALUES
  (
    "Akame",
    "http://pm1.narvii.com/6861/16b7d99ec9bb96863e06d707007086e94bf49c5cr1-1280-720v2_00.jpg",
    "13",
    "Food, Training, Friends"
  );