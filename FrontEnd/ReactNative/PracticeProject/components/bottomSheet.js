import React, { useState } from 'react';
import { BottomSheet } from '@rneui/themed';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import { View, StyleSheet } from "react-native"
import { Icon, Avatar, lightColors, ListItem, Button } from '@rneui/themed';

function BottomSheetComponent() {
    const [isVisible, setIsVisible] = useState(false);
    const list2 = [
        {
            name: 'Amy Farha',
            avatar_url: 'https://uifaces.co/our-content/donated/XdLjsJX_.jpg',
            subtitle: 'Vice President',
            linearGradientColors: ['#FF9800', '#F44336'],
        },
        {
            name: 'Chris Jackson',
            avatar_url: 'https://uifaces.co/our-content/donated/KtCFjlD4.jpg',
            subtitle: 'Vice Chairman',
            linearGradientColors: ['#3F51B5', '#2196F3'],
        },
        {
            name: 'Amanda Martin',
            avatar_url:
                'https://images.unsplash.com/photo-1498529605908-f357a9af7bf5?ixlib=rb-0.3.5&q=80&fm=jpg&crop=faces&fit=crop&h=200&w=200&s=047fade70e80ebb22ac8f09c04872c40',
            subtitle: 'CEO',
            linearGradientColors: ['#FFD600', '#FF9800'],
        },
        {
            name: 'Christy Thomas',
            avatar_url: 'https://randomuser.me/api/portraits/women/48.jpg',
            subtitle: 'Lead Developer',
            linearGradientColors: ['#4CAF50', '#8BC34A'],
        },
        {
            name: 'Melissa Jones',
            avatar_url:
                'https://images-na.ssl-images-amazon.com/images/M/MV5BMTQwMDQ0NDk1OV5BMl5BanBnXkFtZTcwNDcxOTExNg@@._V1_UY256_CR2,0,172,256_AL_.jpg',
            subtitle: 'CTO',
            linearGradientColors: ['#F44336', '#E91E63'],
        },
    ];
    return (
        <SafeAreaProvider>
            <Button
                title="Open Bottom Sheet"
                onPress={() => setIsVisible(!isVisible)}
                buttonStyle={styles.button}
            />
            <BottomSheet modalProps={{}} isVisible={isVisible}>
                <View style={styles.list}>
                    <Button
                        title="Close Bottom Sheet"
                        onPress={() => setIsVisible(!isVisible)}
                        buttonStyle={styles.button}
                    />
                    {list2.map((l, i) => (
                        <ListItem key={i} bottomDivider>
                            <Icon name="user-circle-o" type="font-awesome" color="red" />
                            <ListItem.Content>
                                <ListItem.Title style={{ color: 'red' }}>
                                    {l.name}
                                </ListItem.Title>
                                <ListItem.Subtitle>{l.subtitle}</ListItem.Subtitle>
                            </ListItem.Content>
                            <ListItem.Content right>
                                <ListItem.Title right style={{ color: 'green' }}>
                                    11:00 am
                                </ListItem.Title>
                                <ListItem.Subtitle right>12:00 am</ListItem.Subtitle>
                            </ListItem.Content>
                        </ListItem>
                    ))}
                </View>
            </BottomSheet>
        </SafeAreaProvider>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
    },
    list: {
        marginTop: 20,
        borderTopWidth: 1,
        borderColor: lightColors.greyOutline,
    },
    subtitleView: {
        flexDirection: 'row',
        paddingLeft: 10,
        paddingTop: 5,
    },
    ratingImage: {
        height: 19.21,
        width: 100,
    },
    ratingText: {
        paddingLeft: 10,
        color: 'grey',
    }, button: {
        margin: 10,
    },
});


export default BottomSheetComponent