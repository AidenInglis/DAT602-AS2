DROP DATABASE IF EXISTS gamedb;
CREATE DATABASE gamedb;
USE gamedb;

SET SQL_SAFE_UPDATES = 0; 

DELIMITER $$
CREATE PROCEDURE DIAGNOSTIC(IN Context VARCHAR(255))
BEGIN
	GET DIAGNOSTICS CONDITION 1
			@p1 = RETURNED_SQLSTATE, @p2 = MESSAGE_TEXT;
			 
	SELECT @p1, @p2 As Message;
END $$
DELIMITER ;

-- Table List in Order Here	
-- Item, Player, Game, Tile, Monster, ItemInventory, PlayerChat
DELIMITER $$
CREATE PROCEDURE TablesCreation()
BEGIN
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			-- Drop existing tables if they exist
			DROP TABLE IF EXISTS Item, Player, Game, Tile, Monster, ItemInventory, PlayerChat;

			-- Create tables
			CREATE TABLE Item (
				ItemID INT PRIMARY KEY AUTO_INCREMENT,
				`Name` VARCHAR(255),
				EffectType VARCHAR(255),
				EffectAmount INT
			);

			CREATE TABLE Player (
				PlayerID INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
				`Name` VARCHAR(255) UNIQUE,
				`Password` VARCHAR(255),
				`Status` VARCHAR(255) DEFAULT 'OFFLINE',
				Email VARCHAR(255) UNIQUE,
				Attempts INT DEFAULT 0,
				LOCKED_OUT BOOL DEFAULT FALSE,
				isAdmin BOOL DEFAULT FALSE,
				Wins INT DEFAULT 0,
				Health INT DEFAULT 100,
				Strength INT DEFAULT 10,
				X INT DEFAULT 1, 
				Y INT DEFAULT 1,
				Item VARCHAR(50)
			);

			CREATE TABLE Game (
				GameID INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
				MapID INT,
				`Status` VARCHAR(255)
			);
			
			CREATE TABLE PlayerGame (
				PlayerID INT NOT NULL,
				GameID INT NOT NULL,
				Strength INT DEFAULT 10,
				Health INT DEFAULT 100,
				`Status` VARCHAR(50) DEFAULT 'ALIVE',
                Score INT DEFAULT 0,
				X INT DEFAULT 1,
				Y INT DEFAULT 1,
				PRIMARY KEY (PlayerID, GameID),
				FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID) ON DELETE CASCADE,
				FOREIGN KEY (GameID) REFERENCES Game(GameID) ON DELETE CASCADE
			);	

			CREATE TABLE Tile (
				TileID INT PRIMARY KEY AUTO_INCREMENT,
				GameID INT NOT NULL,
				`Row` INT,
				`Col` INT,
				TileType INT,
				FOREIGN KEY (GameID) REFERENCES Game(GameID) ON DELETE CASCADE
			);

			CREATE TABLE Monster (
				MonsterID INT PRIMARY KEY AUTO_INCREMENT,
				Health INT,
				Strength INT,
				`Status` VARCHAR(255),
				GameID INT,
				X INT,
				Y INT,
				FOREIGN KEY (GameID) REFERENCES Game(GameID) ON DELETE CASCADE
			);

			CREATE TABLE ItemInventory (
				PlayerID INT,
				GameID INT,
				ItemID INT,
				PRIMARY KEY (PlayerID, GameID, ItemID),
				FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID) ON DELETE CASCADE,
				FOREIGN KEY (GameID) REFERENCES Game(GameID) ON DELETE CASCADE,
				FOREIGN KEY (ItemID) REFERENCES Item(ItemID) ON DELETE CASCADE
			);

			CREATE TABLE PlayerChat (
				ChatID INT PRIMARY KEY AUTO_INCREMENT,
				`Timestamp` TIMESTAMP,
				`Text` VARCHAR(255),
				PlayerID INT,
				GameID INT,
				FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID),
				FOREIGN KEY (GameID) REFERENCES Game(GameID)
			);
		COMMIT;
END$$
DELIMITER ;


CALL TablesCreation();


INSERT INTO Item (`Name`, EffectType, EffectAmount) VALUES
    ('Health Potion', 'Health', 50),
    ('Mana Potion', 'Health', 30),
    ('Strength Amulet', 'Damage', 10),
    ('Defense Ring', 'Health', 5),
    ('Suspiscious Stew', 'Health', -20),
    ('LifeLink', 'Health', 10),
    ('Fire Charm', 'Damage', 20),
    ('Elixir of Vitality', 'Health', 25),
    ('Elixir of Vulnerability', 'Health', -25),
    ('Magic Crystal', 'Health', 5);


#DROP PROCEDURE IF EXISTS InsertsCreation;
DELIMITER $$
CREATE PROCEDURE InsertsCreation()
BEGIN
-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

		-- Start the transaction
		START TRANSACTION;
			-- insert statements for tables
			INSERT INTO Player (`Name`, `Password`, `Status`, isAdmin, Email, Wins)
			VALUES 
			('Name1', '12345', 'Online', true, 'aiden@email.com', '0'),
			('Name2', 'Cheese534', 'Online', false, 'miachel@email.com', '1'),
			('Name3', 'Cries123', 'Offline', false, 'jay@email.com', '5');

			INSERT INTO Game (MapID, `Status`)
			VALUES 
			(NULL, 'active'),
			(NULL, 'ended'),
			(NULL, 'active');

			INSERT INTO Map (GameID, ItemID, MonsterNo)
			VALUES 
			(1, 1, 1),
			(2, 2, 2);

			INSERT INTO Tile (MapID, ItemID)
			VALUES 
			(1, 3), -- Tile -- MapID 1, ItemID 3
			(2, 2);

			INSERT INTO Monster (Health, Strength, `Status`, GameID, MapID, X, Y)
			VALUES 
			(100, 30, 'Alive', 1, 1, 10, 10),
			(150, 20, 'Alive', 2, 2, 10, 10);

			INSERT INTO PlayerGame (GameID, PlayerID, Health, Strength)
			VALUES 
			(1, 1, 100, 25),
			(2, 2, 200, 20),
			(1, 3, 200, 20);

			INSERT INTO ItemInventory (PlayerID, GameID, ItemID, ItemType)
			VALUES 
			(1, 1, 1),
			(2, 2, 2);

			INSERT INTO PlayerChat (`Timestamp`, `Text`, PlayerID, GameID)
			VALUES 
			(NOW(), 'Hello, World!', 1, 1),
			(NOW(), 'Game on!', 2, 2);
		COMMIT;
END$$
DELIMITER ;

#CALL InsertsCreation();


-- BOARD CREATION SCRIPTS




#drop table if exists tblTile;
#drop procedure if exists MakeBoard;

CREATE TABLE tblTile (
	TileID INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    GameID INT NOT NULL,
    `row` INT NOT NULL,
    `col` INT NOT NULL,
    TileType INT NOT NULL DEFAULT 0,
    FOREIGN KEY (GameID) REFERENCES Game(GameID) ON DELETE CASCADE
);

#SELECT * FROM tblTile WHERE GameID = 1;

delimiter $$
create procedure MakeBoard(IN pGameID INT, IN mapID INT)
BEGIN
	DECLARE current_row INT DEFAULT 1;
	DECLARE current_col INT DEFAULT 1;
	DECLARE treasure_count INT DEFAULT 0;
	DECLARE monster_tile_id INT;
	DECLARE monster_x INT;
	DECLARE monster_y INT;
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			-- Place player at (1,1)
			INSERT INTO tblTile (GameID, `row`, `col`, TileType)
			VALUES (pGameID, 1, 1, 1); -- TileType 1 represents player

			INSERT INTO tblTile(GameID, `row`, `col`, TileType)
			VALUES (pGameID, 10, 10, 5); -- Insert a monster at 10, 10
			-- Place monster at (10,10) extra for inner join
			INSERT INTO tblTile (GameID, `row`, `col`, TileType)
			VALUES (pGameID, 10, 10, 5);
			
			SET monster_tile_id = LAST_INSERT_ID();

			-- get X, Y coordinates for monster
			SELECT `TileID`, `row`, `col` INTO monster_tile_id, monster_y, monster_x
			FROM tblTile
			WHERE GameID = pGameID AND TileType = 5
			LIMIT 1;
			
			INSERT INTO Monster (GameID, X, Y, Health, Strength, Status)
			VALUES (pGameID, monster_x, monster_y, 100, 10, 'Alive');

			-- Randomly place 4 treasures (TileType 3 represents treasure)
			WHILE treasure_count < 4 DO
				SET current_row = FLOOR(RAND() * 10) + 1;-- get random row and col
				SET current_col = FLOOR(RAND() * 10) + 1;

				-- Ensure no overlap with player and monster, will go around them.
				IF NOT EXISTS (
					SELECT 1 FROM tblTile 
					WHERE `row` = current_row AND `col` = current_col AND GameID = pGameID
				) THEN
					INSERT INTO tblTile (GameID, `row`, `col`, TileType)
					VALUES (pGameID, current_row, current_col, 3);
					SET treasure_count = treasure_count + 1;
				END IF;
			END WHILE;

			-- Fill the rest of the grid with normal tiles
			SET current_row = 1;
			WHILE current_row <= 10 DO
				SET current_col = 1;
				WHILE current_col <= 10 DO
					IF NOT EXISTS (
						SELECT 1 FROM tblTile 
						WHERE `row` = current_row AND `col` = current_col AND GameID = pGameID
					) THEN
						INSERT INTO tblTile (GameID, `row`, `col`, TileType)
						VALUES (pGameID, current_row, current_col, 0); -- TileType 0 represents empty tile
					END IF;
					SET current_col = current_col + 1;
				END WHILE;
				SET current_row = current_row + 1;
			END WHILE;

			#SELECT 'Board created with player, monster, and treasures.' AS MESSAGE;
		COMMIT;
END$$
delimiter ;

INSERT INTO Game (GameID, MapID, Status) VALUES (1, 1, 'active');
CALL MakeBoard(1, 1);
#SELECT * FROM tblTile;


#select * from tblTile;






-- USER SCRIPTS 





DROP USER if exists 'aiden'@'localhost';
CREATE USER 'aiden'@'localhost' IDENTIFIED BY '12345';
GRANT ALL ON gamedb.* TO 'aiden'@'localhost';

#SELECT 'Connected to the DB' as STATUS;

INSERT Player( `Name`, `Password`, Email, isAdmin)
VALUES ('aiden', 'aiden', 'aiden', TRUE),
       ('user', 'user', 'user', FALSE);
       
#SELECT * from Player;
#SELECT * from Game;

#DROP PROCEDURE IF EXISTS Login;
DELIMITER $$
CREATE PROCEDURE Login( IN pName VARCHAR(50), IN pPassword  VARCHAR(50))
COMMENT 'Check login'
BEGIN
	DECLARE numAttempts INT DEFAULT 0;
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			IF pName = '' OR pPassword = '' THEN
				SELECT 'Some fields are Empty, Please fill out all fields' AS MESSAGE;
			END IF;
			-- 'Check for valid login', if valid then select message "Logged in" and reset Attempts to 0, 
			IF EXISTS ( 
				SELECT * FROM Player WHERE `Name` = pName AND `Password` = pPassword and LOCKED_OUT = False)-- grab valid credentials not locked out player then...
			THEN
				UPDATE Player SET Attempts = 0, `Status` = 'ONLINE' WHERE `Name` = pName;
				SELECT CONCAT('Logged In As ', pName) AS Message, pName as `Name`, isAdmin FROM Player Where pName = `Name`;
			ELSE -- else add to Attempts ,
				IF EXISTS(SELECT * FROM Player WHERE `Name` = pName) THEN 
					SELECT Attempts INTO numAttempts FROM Player WHERE `Name` = pName;
					SET numAttempts = numAttempts + 1;
					IF numAttempts > 5 THEN 
					-- if Attempts > 5 then set lockout  to true and select message 'locked out' 
						UPDATE Player
						SET LOCKED_OUT = True
						WHERE 
							 `Name` = pName ;
						 SELECT 'Locked Out, Please contact a Administrator' AS Message, pName as `Name`, isAdmin FROM Player Where pName = `Name`;
					ELSE
					-- else select message 'Bad  password'
						 UPDATE Player
						 SET Attempts = numAttempts
						 WHERE 
							`Name` = pName;
						 SELECT 'Invalid user name and password' AS MESSAGE, pName as `Name`, isAdmin FROM Player Where pName = `Name`;
                         ROLLBACK;
					END IF;
			  ELSE 
				SELECT 'Invalid user name and password' AS MESSAGE, pName as `Name`, isAdmin FROM Player Where pName = `Name`;
                ROLLBACK;
			  END IF;
			END IF;
		COMMIT;
END $$
DELIMITER ;
#CALL Login('aiden', 'aiden');

#DROP PROCEDURE IF EXISTS Logout;
DELIMITER $$
CREATE PROCEDURE Logout(IN pCurrentPlayerName VARCHAR (50))
BEGIN
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			UPDATE Player
			SET `Status` = 'OFFLINE'
			WHERE `Name` = pCurrentPlayerName;
			SELECT 'Player OFFLINE' AS MESSAGE;
		COMMIT;
END $$
DELIMITER ;
#CALL Logout('aiden');

#DROP PROCEDURE IF EXISTS QuitGame;
DELIMITER $$
CREATE PROCEDURE QuitGame(IN pCurrentPlayerName VARCHAR (50))
BEGIN
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			UPDATE Player
			SET `Status` = 'ONLINE'
			WHERE `Name` = pCurrentPlayerName;
			SELECT 'Player ONLINE' AS MESSAGE;
		COMMIT;
END $$
DELIMITER ;
#CALL QuitGame('aiden')

#DROP PROCEDURE IF EXISTS AddUserName;
DELIMITER $$
CREATE PROCEDURE AddUserName(IN pName VARCHAR(50), IN pPassword VARCHAR(50), IN  pEmail VARCHAR(100))
BEGIN
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
		  IF EXISTS (SELECT * FROM Player WHERE `Name` = pName) THEN
			 SELECT 'USERNAME EXISTS' AS MESSAGE;
             ROLLBACK;
		  ELSEIF EXISTS (SELECT * FROM Player WHERE Email = pEmail) THEN
			 SELECT 'EMAIL ALREADY USED' AS MESSAGE;
             ROLLBACK;
		  ELSE 
			IF pName = '' OR pPassword = '' OR pEmail = '' THEN
				SELECT 'Some fields are Empty, Please fill out all fields' AS MESSAGE;
                ROLLBACK;
			ELSEIF LENGTH(pName) < 5 OR LENGTH(pPassword) < 5 OR LENGTH(pEmail) < 5 THEN
				SELECT 'All fields require at least five characters.' AS MESSAGE;
                ROLLBACK;
			ELSE
				INSERT INTO Player(`Name`, `Password`, Email, `Status`)
				VALUE (pName, pPassword, pEmail, 'OFFLINE');
				SELECT 'ADDED USER NAME' AS MESSAGE, pName as `Name`, isAdmin FROM Player Where pName = `Name`;
			END IF;
		  END IF;
		COMMIT;
END $$
DELIMITER ;
#CALL AddUserName('jonas', 'password', 'jonas@email.com');

#DROP PROCEDURE IF EXISTS DeletePlayer;
DELIMITER $$
CREATE PROCEDURE DeletePlayer(IN `pName` VARCHAR(50))
BEGIN
	DECLARE resultMessage VARCHAR(100);
	DECLARE PlayerID INT;
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			-- Check if the player exists
			IF EXISTS (SELECT 1 FROM Player WHERE Name = pName AND isAdmin = FALSE) THEN
				SELECT P.PlayerID INTO PlayerID FROM Player P WHERE Name = pName;
				DELETE FROM PlayerGame WHERE PlayerID = PlayerID;
				DELETE FROM Player WHERE PlayerID = PlayerID AND isAdmin = FALSE;-- Delete the player from Player table

				SET resultMessage = CONCAT('Player ', pName, ' deleted successfully.');
			ELSE
				SET resultMessage = CONCAT('Player not found or is an Admin. You tried searching for user: ', pName);
                ROLLBACK;
			END IF;
			SELECT resultMessage AS Message;-- Return the result message
		COMMIT;
END $$
DELIMITER ;
#Call DeletePlayer('user');

#DROP PROCEDURE IF EXISTS GetPlayerByName;
DELIMITER $$
CREATE PROCEDURE GetPlayerByName(IN pName VARCHAR(50))
BEGIN
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			SELECT Name, Password, Email
			FROM Player
			WHERE Name = pName;
		COMMIT;
END $$
DELIMITER ;
#CALL UpdatePlayer('aiden', 'aiden_new', 'newPassword', 'newEmail@example.com');

#DROP PROCEDURE IF EXISTS UpdatePlayer;
DELIMITER $$
CREATE PROCEDURE UpdatePlayer(IN pName VARCHAR(50), IN pNewName VARCHAR(50), IN pPassword VARCHAR(50), IN pEmail VARCHAR(100))
BEGIN
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			UPDATE Player
			SET `Password` = pPassword, Email = pEmail, `Name` = pNewName
			WHERE `Name` = pName;
            
            SELECT 'Player details updated successfully.' AS Message;
		COMMIT;
END $$
DELIMITER ;
#CALL UpdatePlayer('aiden', 'ayden', 'aiden', 'aiden@email.com');

#DROP PROCEDURE IF EXISTS DeleteGame;
DELIMITER $$
CREATE PROCEDURE DeleteGame(IN `pGameID` VARCHAR(50))
BEGIN
    DECLARE resultMessage VARCHAR(100);
    
    -- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		CALL DIAGNOSTIC('DeleteGame - SQLEXCEPTION');
        ROLLBACK;
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('DeleteGame - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			-- Check if the game exists
			IF EXISTS (SELECT 1 FROM Game WHERE GameID = pGameID) THEN
				DELETE FROM Game WHERE GameID = pGameID;
				SET resultMessage = CONCAT('Game ', pGameID, ' deleted successfully.');
			ELSE
				SET resultMessage = CONCAT('Game not found. You tried searching for game: ', pGameID);
                
			END IF;
			
			-- Return the result message
			SELECT resultMessage AS Message;
		COMMIT;
END $$
DELIMITER ;
#CALL DeleteGame(1);

#DROP PROCEDURE IF EXISTS CreateNewGameInDatabase;
DELIMITER $$
CREATE PROCEDURE CreateNewGameInDatabase(IN mapID INT ,IN pCurrentPlayerName VARCHAR(50))
BEGIN
	DECLARE localPlayerID INT;
    DECLARE localGameID INT;
    
    -- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			INSERT INTO Game(mapID, `status`)
			VALUES (mapID, 'active');
			SELECT P.PlayerID INTO localPlayerID from Player P Where `Name` = pCurrentPlayerName;-- set PlayerID
			SELECT MAX(G.GameID) INTO localGameID FROM Game G;-- set GameID
			INSERT INTO PlayerGame(PlayerID, GameID)-- create playergame instance/variable or something.
			VALUES (localPlayerID, localGameID);
			UPDATE Player
			SET `Status` = 'IN GAME'
			WHERE `Name` = pCurrentPlayerName;
				
			CALL MakeBoard(localGameID, mapID);
			
			SELECT CONCAT('game made,', localGameID) AS MESSAGE;
		COMMIT;
END $$	
DELIMITER ;
#CALL CreateNewGameInDatabase(1, 'aiden');

#DROP PROCEDURE IF EXISTS JoinGame;
DELIMITER $$
CREATE PROCEDURE JoinGame(IN pGameID INT, IN pCurrentPlayer VARCHAR(50))
BEGIN
    DECLARE localPlayerID INT;
    
    -- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			-- Retrieve the Player ID for the current player
			SELECT PlayerID INTO localPlayerID
			FROM Player
			WHERE `Name` = pCurrentPlayer;
			
			-- Check if the player and game exist
			IF localPlayerID IS NULL THEN
				SELECT 'Player not found' AS MESSAGE;
                ROLLBACK;
			ELSEIF NOT EXISTS (SELECT 1 FROM Game WHERE GameID = pGameID) THEN
				SELECT 'Game not found' AS MESSAGE;
                ROLLBACK;
			ELSE
				-- Add the player to the game
				IF NOT EXISTS (SELECT * FROM PlayerGame WHERE PlayerID = localPlayerID) THEN
					INSERT INTO PlayerGame (GameID, PlayerID)
					VALUES (pGameID, localPlayerID);
				END IF;
				-- Confirm join success
				SELECT 'Joined Game Successfully' AS MESSAGE;
			END IF;
		COMMIT;
END $$
DELIMITER ;
#CALL JoinGame(1, 'aiden');

#DROP PROCEDURE IF EXISTS GetPlayerLocation;
DELIMITER $$
CREATE PROCEDURE GetPlayerLocation(IN pGameID INT, IN pCurrentPlayerName VARCHAR(50))
BEGIN
    DECLARE localPlayerID INT;
    DECLARE localX INT;
    DECLARE localY INT;
    
    -- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			-- Get the PlayerID based on the player name
			SELECT PlayerID INTO localPlayerID FROM Player WHERE `Name` = pCurrentPlayerName;
			
			SELECT X, Y INTO localX, localY FROM PlayerGame 
			WHERE GameID = pGameID AND PlayerID = localPlayerID;
			
			SELECT CONCAT(localX,',', localY) AS MESSAGE;
		COMMIT;
END $$
DELIMITER ;
#CALL GetPlayerLocation(1, 'aiden');

#DROP PROCEDURE IF EXISTS GetAllPlayers;
DELIMITER $$
CREATE PROCEDURE GetAllPlayers()
BEGIN
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			SELECT `Name`, Wins
			FROM Player ;
		COMMIT;
END $$
DELIMITER ;
#CALL GetAllPlayer;

#DROP PROCEDURE IF EXISTS GetAllGames
DELIMITER $$
CREATE PROCEDURE GetAllGames()
BEGIN
	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			SELECT GameID, MapID, `Status`
			FROM Game ;
		COMMIT;
END $$
DELIMITER ;
#CALL GetAllGames;

#DROP PROCEDURE IF EXISTS GetAllItems
DELIMITER $$
CREATE PROCEDURE GetAllItems(IN CurrentPlayerName VARCHAR(50), IN GameID INT)
BEGIN
	DECLARE localPlayerID INT;
    
    -- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			SELECT PlayerID INTO localPlayerID FROM Player WHERE `Name` = CurrentPlayerName;
			SELECT Item.`Name`, 
				Item.EffectType, 
				Item.EffectAmount, Item.ItemID FROM Item
			INNER JOIN ItemInventory ON Item.ItemID = ItemInventory.ItemID
			WHERE ItemInventory.PlayerID = localPlayerID AND ItemInventory.GameID = GameID;
		COMMIT;
END $$
DELIMITER ;
#CALL GetAllItems('aiden', 1);

-- MOVE PLAYER FUNCTIONALITY

#DROP PROCEDURE IF EXISTS MovePlayer;
DELIMITER $$
CREATE PROCEDURE MovePlayer(IN pnewRow INT, IN pnewCol INT, IN pGameID INT, IN pCurrentPlayerName VARCHAR(50))
BEGIN
	DECLARE localPlayerID INT;
    DECLARE localTileType INT;
    
    -- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			SELECT PlayerID INTO localPlayerID FROM Player Where `Name` = pCurrentPlayerName;
			
			UPDATE playerGame
			Set X = pnewRow, Y = pnewCol
			WHERE PlayerID = localPlayerID AND GameID = pGameID;
			SELECT TileType INTO localTileType FROM tblTile WHERE GameID = pGameID AND  `row` = pnewRow AND `col` = pnewCol;
			IF localTileType = 5 THEN 
				SELECT 'Cannot Move to enemy tile' AS MESSAGE;
                ROLLBACK;
			ELSEIF localTileType = 3 THEN 
				CALL GetTreasure(localPlayerID, pGameID);
				SELECT CONCAT('Found Treasure at ', pNewCol, ', ', pNewRow) AS MESSAGE;
				UPDATE tblTile SET TileType = 0 
				WHERE GameID = pGameID AND TileType = 1;-- not good for multiple players as it just overwrites all player positions to this one.
				UPDATE tblTile Set TileType = 1 
				WHERE GameID = pGameID AND  `row` = pnewRow AND `col` = pnewCol;
				SELECT CONCAT('Player Moved Successfully to ', pNewCol, ', ', pNewRow) AS MESSAGE;
			
			ELSEIF localTileType = 0 THEN
				UPDATE tblTile SET TileType = 0 
				WHERE GameID = pGameID AND TileType = 1;-- not good for multiple players as it just overwrites all player positions to this one.
				UPDATE tblTile Set TileType = 1 
				WHERE GameID = pGameID AND  `row` = pnewRow AND `col` = pnewCol;
				SELECT 'Player Moved Successfully' AS MESSAGE;
                
				UPDATE playerGame
				SET Score = Score + 1
				WHERE GameID = pGameID AND PlayerID = localPlayerID;
                
			ELSEIF localTileType = 1 THEN
				SELECT 'Player attempted to move to center or another player' AS MESSAGE;
                ROLLBACK;
			END IF;
		COMMIT;
END $$
DELIMITER ;
#CALL MovePlayer(2, 3, 1, "aiden");

#DROP PROCEDURE IF EXISTS GetTreasure;
DELIMITER $$
CREATE PROCEDURE GetTreasure(IN localPlayerID INT,IN pGameID INT)
BEGIN
	DECLARE itemNumber INT;
	DECLARE localItemID INT;
    
    -- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			item_selection_loop: LOOP
			-- rand 1-how ever many items
				SET itemNumber = FLOOR(RAND() * 10) + 1;
				
				SELECT ItemID INTO localItemID 
				FROM Item 
				WHERE ItemID = itemNumber
				  AND ItemID NOT IN (
					  SELECT ItemID 
					  FROM ItemInventory 
					  WHERE PlayerID = localPlayerID 
						AND GameID = pGameID
				  )
				LIMIT 1;
				IF localItemID IS NOT NULL THEN
					INSERT INTO ItemInventory (PlayerID, GameID, ItemID)
					VALUES (localPlayerID, pGameID, localItemID);
					LEAVE item_selection_loop;
				ELSE
					LEAVE item_selection_loop;
				END IF;
			END LOOP item_selection_loop;
		COMMIT;
END $$
DELIMITER ;
#CALL GetTreasure(1, 1);

#DROP PROCEDURE IF EXISTS GetMonster;
DELIMITER $$
CREATE PROCEDURE GetMonster(IN pgameID INT)
BEGIN
	DECLARE localMonsterPositionY INT;
	DECLARE localMonsterPositionX INT;

	-- Define an error handler for SQL exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLEXCEPTION');
    END;

    -- Define an error handler for SQL warnings
    DECLARE EXIT HANDLER FOR SQLWARNING
    BEGIN
        ROLLBACK;
        CALL DIAGNOSTIC('INSERTCHECK - SQLWARNING');
    END;

    -- Start the transaction
		START TRANSACTION;
			SELECT X, Y INTO localMonsterPositionX, localMonsterPositionY FROM Monster WHERE GameID = pgameID;
		COMMIT;
END $$
DELIMITER ;
#CALL GetMonster(1);

DROP PROCEDURE IF EXISTS MonsterMove;
DELIMITER $$
CREATE PROCEDURE MonsterMove(IN pgameID INT)
BEGIN
	DECLARE localMonsterPositionY INT;
	DECLARE localMonsterPositionX INT;
    DECLARE newX INT;
    DECLARE newY INT;
    DECLARE targetTileType INT;
    DECLARE currentScore INT;

	-- Define an error handler for SQL exceptions
    #DECLARE EXIT HANDLER FOR SQLEXCEPTION
    #BEGIN
    #    ROLLBACK;
    #    CALL DIAGNOSTIC('MonsterMove - SQLEXCEPTION');
    #END;

    -- Define an error handler for SQL warnings
    #DECLARE EXIT HANDLER FOR SQLWARNING
    #BEGIN
    #    ROLLBACK;
    #    CALL DIAGNOSTIC('MonsterMove - SQLWARNING');
    #END;

    -- Start the transaction
		START TRANSACTION;
			SELECT X, Y INTO localMonsterPositionX, localMonsterPositionY FROM Monster WHERE GameID = pgameID;
			SET newX = localMonsterPositionX + (FLOOR(RAND() * 3) - 1); -- random moves -1, 0, or +1
			SET newY = localMonsterPositionY + (FLOOR(RAND() * 3) - 1); -- random moves -1, 0, or +1
			
			IF newX < 1 THEN
				SET newX = 1;
			ELSEIF newX > 10 THEN
				SET newX = 10;
			END IF;

			IF newY < 1 THEN
				SET newY = 1;
			ELSEIF newY > 10 THEN
				SET newY = 10;
			END IF;
			
             SELECT TileType INTO targetTileType
			FROM tblTile
			WHERE GameID = pgameID AND `row` = newY AND `col` = newX;

			-- If the target tileType is 1, game over
			IF targetTileType = 1 THEN
				-- Send a message indicating game over
				SELECT 'Game Over - Player Died' AS MESSAGE;
			ELSE
				UPDATE Monster 
				SET X = newX, Y = newY 
				WHERE GameID = pgameID;
				
				UPDATE tblTile
				SET TileType = 0  -- Set the old monster's tile to 0 (empty)
				WHERE GameID = pgameID AND `row` = localMonsterPositionY AND `col` = localMonsterPositionX AND TileType = 5;

				-- Set the new tile to TileType 5 (monster)
				UPDATE tblTile
				SET TileType = 5  -- Set the new monster's tile to 5 (monster)
				WHERE GameID = pgameID AND `row` = newY AND `col` = newX;
                
                 UPDATE Player p
				JOIN playerGame pg ON p.PlayerID = pg.PlayerID
				SET p.wins = p.wins + 1
				WHERE pg.GameID = pgameID;
				
				SELECT 'monsterMove has been called in SQL' AS MESSAGE; 
			END IF;
		COMMIT;
END $$
DELIMITER ;
#CALL MonsterMove(1);