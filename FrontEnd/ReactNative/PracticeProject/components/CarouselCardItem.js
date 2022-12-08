import React from 'react'
import { View, Text, StyleSheet, Dimensions, Image } from "react-native"
import Carousel, { ParallaxImage } from 'react-native-snap-carousel';
export const SLIDER_WIDTH = Dimensions.get('window').width + 80
export const ITEM_WIDTH = Math.round(SLIDER_WIDTH * 0.7)

const { width: screenWidth } = Dimensions.get('window')

const CarouselCardItem = ({ item, index }, parallaxProps) => {
    return (
        <View style={styles.item}>
            <ParallaxImage
                source={{ uri: item.imgUrl }}
                containerStyle={styles.imageContainer}
                style={styles.imgUrl}
                parallaxFactor={0.4}
                {...parallaxProps}
            />
        </View>
    )
}

const styles = StyleSheet.create({
    item: {
        width: screenWidth - 60,
        height: screenWidth - 60,
    },
    imageContainer: {
        flex: 1,
        marginBottom: Platform.select({ ios: 0, android: 1 }), // Prevent a random Android rendering issue
        backgroundColor: 'white',
        borderRadius: 8,
    },
    image: {
        ...StyleSheet.absoluteFillObject,
        resizeMode: 'cover',
    },
})

export default CarouselCardItem