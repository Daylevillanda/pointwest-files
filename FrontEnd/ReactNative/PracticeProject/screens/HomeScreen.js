import React from "react";
import { StyleSheet, View, SafeAreaView } from "react-native"
import HeaderComponent from "../components/header";
import CarouselCards from '../components/CarouselCards'
import BottomSheetComponent from '../components/bottomSheet'
import { Button } from '@rneui/themed'

export default function HomeScreen({ navigation }) {
    return (
        <SafeAreaView style={styles.container}>
            <View style={{ height: '90%', bottom: 0 }}>
                <HeaderComponent />
                <CarouselCards />
                <Button
                    buttonStyle={styles.button}
                    title="Scan Fingerprint"
                    onPress={() => navigation.navigate("FingerPrint")}
                ></Button>
            </View>
            <View style={{ height: '10%' }}>
                <BottomSheetComponent />
            </View>
        </SafeAreaView >
    );
}

const styles = StyleSheet.create({
    container: {
        marginTop: 10,
        height: '100%',
        backgroundColor: 'black',
        padding: 20,
        flexDirection: 'column',
        justifyContent: 'space-between'
    }, button: {
        margin: 10,
    }
});
