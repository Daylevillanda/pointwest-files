import { Dimensions, StyleSheet, Text, View } from "react-native";
import React from "react";
  
const GeeksforGeeks = (props) => {
    return (
        <View style={styles.container}>
            <Text style={styles.title}>{props.name}</Text>
        </View>
    );
  };
  
export default GeeksforGeeks;
  
const styles = StyleSheet.create({
    container: {
        marginTop: 200,
        height: 400,
        width: Dimensions.get("window").width,
        // width: 300,
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "#3B5323",
        borderColor: "#000",
        borderWidth: 2,
        alignSelf: "center",
     },
    title: {
        color: "#fff",
        fontSize: 20,
     },
});