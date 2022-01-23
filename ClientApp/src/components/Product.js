import React, { Component } from 'react';
import { Button } from 'reactstrap';
import { useState } from 'react';
import { useEffect } from 'react';

export function Product(props) {

  useEffect(
    () => {
      props.updateCart(props.data.productId, 0);  
    }, 
    []
  )

  return (
    <div style={{width: "100%", paddingTop: "5%", paddingLeft: "5%", paddingBottom: "5%", backgroundColor: "#ccc", marginTop: "10px" }}>
      <div style={{position: "absolute", backgroundColor: "white", marginLeft: "40%", height: "15%", width: "45%" }}>
        <div style={{marginLeft: "5%", marginTop: "5%"}}>
          <h4>{props.data.name}</h4>
          <p>{props.data.priceString}</p>
          <Button color="primary" style={{width: "20%"}} onClick={ClickMinus}>-</Button>
          <span style={{marginLeft: "5%", marginRight: "5%"}}>{props.data.count}</span>
          <Button color="primary" style={{width: "20%"}} onClick={ClickPlus}>+</Button>
        </div>          
      </div>
      <img src={props.data.imageUrl} style={{width: "40%" }} /> 
    </div>
  );

  function ClickPlus() {
    const newCount = props.data.count + 1;
    props.updateCart(props.data.productId, newCount);
  }

  function ClickMinus() {
    const newCount = Math.max(0, props.data.count - 1);  
    props.updateCart(props.data.productId, newCount);
  }
}


