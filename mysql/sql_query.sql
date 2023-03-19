SELECT VERSION();

/*
CREATE TABLE IF NOT EXISTS airplanes (
  plane_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  manufacturer VARCHAR(50) NOT NULL,
  model VARCHAR(50) NOT NULL,
  engine_type VARCHAR(50) NOT NULL,
  engine_count TINYINT NOT NULL,
  wingspan DECIMAL(5,2) NOT NULL,
  plane_length DECIMAL(5,2) NOT NULL,
  max_weight MEDIUMINT UNSIGNED NOT NULL,
  icao_code CHAR(4) NOT NULL,
  create_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  last_update timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (plane_id))
ENGINE=InnoDB AUTO_INCREMENT=101;

*/


INSERT INTO airplanes 
  (manufacturer, model, engine_type, engine_count, 
    wingspan, plane_length, max_weight, icao_code)
VALUES 
  ('Airbus', 'A380-800', 'jet', '4', 261.65, 238.62, 1267658, 'A388');

SELECT * FROM airplanes;

--delete from airplanes where plane_id in (102,103)



INSERT INTO airplanes 
  (manufacturer, model, engine_type, engine_count, 
    wingspan, plane_length, max_weight, icao_code)
VALUES 
  ('Piper', 'J-3 Cub', 'piston', '1', 38.00, 22.42, 1220, 'J3'),
  ('Beechcraft', '1900C', 'turboprop', '2', 54.50, 57.83, 16600, 'B190');
  
 SELECT model, engine_type, engine_count
FROM Airplanes
WHERE manufacturer = 'Airbus';


  
  
 