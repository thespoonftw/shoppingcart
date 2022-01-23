import React, { Component, useEffect } from 'react';
import { Product } from './Product';
import { Offer } from './Offer';
import { Basket } from './Basket';
import { useState } from 'react';

export function Shop() {

  const [productData, setProductData] = useState(null);

  useEffect(
    () => {
      const fetchData = async() => {
        const response = await fetch('product');
        const json = await response.json();
        setProductData(json);
      }
      fetchData();      
    }, 
    []
  )

  return (
    <div className="container">
      <div className="row">
        <div className="col-md">
          <h3>Products</h3>         
          {productData ? productData.map(p => <Product key={p.productId} data={p} updateCart={UpdateCart} />) : <></>}
        </div>
        <div className="col-md">
          <h3>Offers</h3>
          <Offer text="When you buy a cheese, get a second cheese free!" />
          <Offer text="When you buy a Soup, you get a half price Bread!" />
          <Offer text="Get a third off Butter!" />
          <h3 style={{marginTop: "25px"}}>Basket</h3>
          <Basket productData={productData}/>
        </div>
      </div>
    </div>
  );

  function UpdateCart(productId, amount) {
    var newData = productData.slice();
    newData[productId].count = amount;
    setProductData(newData);
    //console.log("update cart: " + productId + " " + amount);
    //console.log(productData);
  }

}