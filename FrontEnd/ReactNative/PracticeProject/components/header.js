import React, { useState } from "react";
import { StyleSheet, View, TouchableOpacity } from "react-native"
import { Icon, Avatar } from '@rneui/themed';

function HeaderComponent() {
    return (
        <View style={styles.headerContainer}>
            <View style={{ borderWidth: 1, borderRadius: 12, borderColor: 'transparent', backgroundColor: '#1C1C1E' }}>
                <TouchableOpacity>
                    <Icon
                        iconStyle={{ padding: 10 }}
                        name='setting'
                        type='antdesign'
                        color='white'
                        size={20}
                    ></Icon>
                </TouchableOpacity>
            </View>
            <View>
                <Avatar
                    size={70}
                    rounded
                    source={{ uri: 'https://cdn.pixabay.com/photo/2016/11/21/12/42/beard-1845166_1280.jpg' }}
                    containerStyle={{ padding: 10 }}
                />
            </View>

            <View style={{ borderWidth: 1, borderRadius: 12, borderColor: 'transparent', backgroundColor: '#1C1C1E' }}>
                <TouchableOpacity>
                    <Icon
                        iconStyle={{ padding: 10 }}
                        name='notifications'
                        type='material'
                        color='white'
                        size={20}
                    ></Icon>
                </TouchableOpacity>
            </View>
        </View >
    )
}

const styles = StyleSheet.create({
    headerContainer: {
        flexDirection: 'row',
        alignItems: 'center',
        backgroundColor: 'red',
        height: '12%',
        justifyContent: 'space-between',
        backgroundColor: 'black',
    }
});

export default HeaderComponent;
