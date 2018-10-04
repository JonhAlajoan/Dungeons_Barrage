<?php 
//change this line
$mysqli = mysqli_connect("localhost", "id2353563_admin", "852456ru", "id2353563_bdhighscore") or die("Error loading db");

$table = $mysqli->real_escape_string($_GET['table']);
$query = "SELECT id,name,score FROM ".$table." ORDER BY score DESC LIMIT 5";
$result = $mysqli->query($query) or trigger_error($mysqli->error);
$numrows = $result->num_rows;
if ($numrows <= 0){
	echo "{ error: \"No entries found.\" }";
}else{
	$resultarray = array();
	while ($row = $result->fetch_array()){
		$resultarray[$row['id']] = array();
		$resultarray[$row['id']]['name'] = $row['name'];
		$resultarray[$row['id']]['score'] = $row['score'];
	}
	echo json_encode($resultarray);
	/*
	for ($i = 0; $i < $numrows; $i++){
		$row = $mysqli->fetch_array($result);
		$resultstring .= "name: \"".$row{'name']
	}
	*/
}
?>