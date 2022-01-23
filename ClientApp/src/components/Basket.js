import React, { Component } from 'react';
import { useEffect, useState } from 'react';

export function Basket(props) {

  const [basketData, setBasketData] = useState(null);

  useEffect(
    () => {
      const id = props.productData ? props.productData[0].count: 0;
      const fetchData = async() => {
        const response = await fetch('basket/' + GetRequestString());
        const json = await response.json();
        console.log(json);
        setBasketData(json);
      }
      fetchData();      
    }, 
    [props.productData]
  )

  return (
    <div style={{width: "100%", paddingTop: "2%", paddingLeft: "5%", paddingBottom: "1%", backgroundColor: "#ccc", marginTop: "10px", minHeight: "100px" }}>
      { basketData ? 
        <div>
          {
            basketData.items.map(item => 
              <p>{item}</p>
            )
          }
          <p><b>Subtotal: </b>{basketData.subTotal}</p> 
          <br></br>
          {
            basketData.discounts.map(item => 
              <p>{item}</p>
            )
          }
          <p><b>Total:</b> {basketData.total}</p>

        </div>        
       : 
       <p><b>Basket Is Empty</b></p>
      }
    </div>
  );

  function GetRequestString() {
    if (!props.productData) { return ""; }
    var stringBuilder = "";
    props.productData.filter(p => p.count > 0).map(p =>
      stringBuilder += p.productId + "-" + p.count + "_"
      );
    return stringBuilder.slice(0, -1);
  }
  
  /*
  return (
    <div style={{width: "100%", paddingTop: "2%", paddingLeft: "5%", paddingBottom: "1%", backgroundColor: "#ccc", marginTop: "10px" }}>
      <p>2x Cheese £2.40</p>
      <p>2x Cheese £2.40</p>
      <p><b>Subtotal:</b> £5.20</p>
      <p>1x BOGOF Cheese -£1.20</p>
      <p><b>Final total: </b> £5.20</p>
    </div>
  );
  */
}
