import React from 'react'
import { View, Dimensions } from "react-native"
import Carousel from 'react-native-snap-carousel'
import CarouselCardItem, { SLIDER_WIDTH, ITEM_WIDTH } from './CarouselCardItem'
import data from '../assets/mock/data'

const { width: screenWidth } = Dimensions.get('window')

const CarouselCards = () => {
    const isCarousel = React.useRef(null)

    return (
        <View style={{
            alignItems: 'center',
            justifyContent: 'center'
        }}>
            <Carousel
                sliderWidth={screenWidth}
                sliderHeight={screenWidth}
                itemWidth={screenWidth - 60}
                data={data}
                renderItem={CarouselCardItem}
                hasParallaxImages={true}
            />
        </View>
    )
}


export default CarouselCards