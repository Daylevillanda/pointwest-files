// import { StyleSheet, View, FlatList, Dimensions } from "react-native";
// import { useState } from "react";
// import GeeksforGeeks from "./GeeksforGeeks";
  
// export default function App() {
//     const [items, setItems] = useState([
//         {
//             id: "1",
//             name: "GeeksforGeeks View 1",
//         },
//         {
//             id: "2",
//             name: "GeeksforGeeks View 2",
//         },
//         {
//             id: "3",
//             name: "GeeksforGeeks View 3",
//         },
//         {
//             id: "4",
//             name: "GeeksforGeeks View 4",
//         },
//   ]);
    
//     return (
//         <View>
//             <FlatList
//                 data={items}
//                 renderItem={({ item }) => <GeeksforGeeks name={item.name} />}
//                 keyExtractor={(item) => item.id}
//                 snapToAlignment="end"
//                 decelerationRate={"fast"}
//                 snapToInterval={Dimensions.get("window").width}
//                 horizontal
//             />
//         </View>
//   );
// }
  
// const styles = StyleSheet.create({
//     container: {
//         flex: 1,
//         backgroundColor: "#fff",
//         alignItems: "center",
//         justifyContent: "center",
//     },
// });
import { Entypo, Feather } from '@expo/vector-icons';
import React, {useEffect, useRef, useState} from 'react';
import { Dimensions, FlatList, Text, TouchableOpacity, View } from 'react-native';

const { width, height } = Dimensions.get('screen');
const data = [{
  key: "1",
  job: "GeeksforGeeks View 1",
},
{
  key: "2",
  job: "GeeksforGeeks View 2",
},
{
  key: "3",
  job: "GeeksforGeeks View 3",
},
{
  key: "4",
  job: "GeeksforGeeks View 4",
}]

const _colors = {
  active: `#FCD259ff`,
  inactive: `#FCD25900`,
};
const _spacing = 10;

export default function App() {
  const [index, setIndex] = useState(0)
  const [viewPosition, setViewPosition] = useState(0)
  const ref = useRef(null);
  useEffect(()=>{
    ref.current.scrollToIndex({
      index,
      animated: true,
      viewPosition,
      // viewOffset: viewPosition === 0.5 || viewPosition === 1? 0: _spacing,
      viewOffset: viewPosition === 0.5 || viewPosition === 1? 0: _spacing,
    })
  },[index, viewPosition])
  
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <FlatList
        ref={ref}
        initialScrollIndex = {index}
        style={{ flexGrow: 0, paddingLeft:index === 0? (width-200)/2: 0 }}
        data={data}
        keyExtractor={(item) => item.key}
        contentContainerStyle={{ paddingLeft: _spacing }}
        showsHorizontalScrollIndicator={false}
        horizontal
        renderItem={({ item, index: fIndex }) => {
          return (
            <TouchableOpacity onPress={() => {
              setIndex(fIndex)
            }}>
              <View
                style={{
                  marginRight: _spacing,
                  padding: _spacing,
                  borderWidth: 2,
                  borderColor: _colors.active,
                  borderRadius: 12,
                  backgroundColor: fIndex === index? _colors.active: _colors.inactive,
                  width: 200
                }}>
                <Text style={{ color: '#36303F', fontWeight: '700' }}>
                  {item.job}
                </Text>
              </View>
            </TouchableOpacity>
          );
        }}
      />
      <View
        style={{
          alignItems: 'center',
          flexDirection: 'row',
          marginTop: _spacing * 10,
        }}>
        <View style={{ alignItems: 'center' }}>
          <Text
            style={{
              color: '#36303F',
              fontWeight: '700',
              marginBottom: _spacing,
            }}>
            Scroll position
          </Text>
          <View
            style={{
              flexDirection: 'row',
              width: width / 2,
              justifyContent: 'center',
            }}>
            <TouchableOpacity onPress={() => {
              setViewPosition(0)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                  marginRight: _spacing,
                }}>
                <Entypo name='align-left' size={24} color='#36303F' />
              </View>
            </TouchableOpacity>
            <TouchableOpacity onPress={() => {
              setViewPosition(0.5)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                  marginRight: _spacing,
                }}>
                <Entypo
                  name='align-horizontal-middle'
                  size={24}
                  color='#36303F'
                />
              </View>
            </TouchableOpacity>
            <TouchableOpacity onPress={() => {
              setViewPosition(1)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                }}>
                <Entypo name='align-right' size={24} color='#36303F' />
              </View>
            </TouchableOpacity>
          </View>
        </View>
        <View style={{ alignItems: 'center' }}>
          <Text
            style={{ color: '#36303F', fontWeight: '700', marginBottom: 10 }}>
            Navigation
          </Text>
          <View
            style={{
              flexDirection: 'row',
              width: width / 2,
              justifyContent: 'center',
            }}>
            <TouchableOpacity onPress={() => {
              if (index === 0 ){
                return;
              }
              setIndex(index - 1)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                  marginRight: _spacing,
                }}>
                <Feather name='arrow-left' size={24} color='#36303F' />
              </View>
            </TouchableOpacity>
            <TouchableOpacity onPress={() => {
              if (index === data.length -1 ){
                return;
              }
              setIndex(index + 1)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                }}>
                <Feather name='arrow-right' size={24} color='#36303F' />
              </View>
            </TouchableOpacity>
          </View>
        </View>
      </View>
    </View>
  );
}