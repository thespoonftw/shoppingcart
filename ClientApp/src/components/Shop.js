import React, { useEffect, useState } from 'react';
import { Products } from './Products';
import { Offers } from './Offers';
import { Basket } from './Basket';

export function Shop() {

  // useState hook for the current state of the shop
  const [shopState, setShopState] = useState(null);

  // hook called once when the component is mounted. Api initialises state of shop
  useEffect(
    () => {
      const fetchData = async() => {
        const response = await fetch('product');
        const json = await response.json();
        // set number of each item in cart to zero
        json.map(product => product.count = 0); 
        setShopState(json);
      }
      fetchData();      
    }, 
    []
  )

  return (
    <div className="container">
      <div className="row">
        <Products shopState={shopState} setShopState={setShopState}/>
        <div className="col-md">
          <Offers />
          <Basket shopState={shopState}/>
        </div>
      </div>
    </div>
  );
}