<?php 
//change these lines
$mysqli = mysqli_connect("localhost", "id2353563_admin", "852456ru", "id2353563_bdhighscore") or die("Error loading db");
$secret = "852456ru";

//do not change
$name = $_GET['name'];
$score = $_GET['score'];
$hash = $_GET['hash'];
$table = $mysqli->real_escape_string($_GET['table']);
$realhash = md5($name.$score.$secret);
if ($realhash == $hash){
	$query = "CREATE TABLE IF NOT EXISTS ".$table." (
		`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY ,
		`name` VARCHAR( 255 ) NOT NULL ,
		`score` FLOAT NOT NULL ,
		`timestamp` TIMESTAMP NOT NULL
		) ENGINE = MYISAM ;";
	$mysqli->query($query) or trigger_error($mysqli->error);
	$stmt = $mysqli->prepare("INSERT INTO ".$table."(name, score) VALUES (?,?)") or trigger_error("error in query: ".$mysqli->error);
	$stmt->bind_param("si", $name, intval($score));
	$stmt->execute();
}else trigger_error("hash not fitting!");
?>