import React from 'react';
import { Button } from 'reactstrap';

// All styling should be ideally moved into .css files
export function Products(props) {

  // render one of the items in the product list
  function renderProduct(product) {
    return (
      <div key={product.productId} style={{width: "100%", paddingLeft: "5%", marginTop: "10px" }}>
        <div style={{position: "absolute", marginLeft: "30%", height: "15%", width: "45%" }}>
          <div style={{marginLeft: "5%", marginTop: "5%"}}>
            <h4>{product.name}</h4>
            <p>{product.priceString}</p>

            <Button color="primary" style={{width: "20%"}} 
              onClick={() =>
                updateCart(product.productId, Math.max(0, product.count - 1))
              }>-</Button>

            <span style={{marginLeft: "5%", marginRight: "5%"}}>{product.count}</span>

            <Button color="primary" style={{width: "20%"}} 
              onClick={() =>
                updateCart(product.productId, product.count + 1)
              }>+</Button>
          </div>          
        </div>
        <img alt={product.name} src={product.imageUrl} style={{width: "30%" }} /> 
      </div>
    );
  }
  
  // When button is clicked, update the state of the shop
  function updateCart(productId, amount) {
    var newData = props.shopState.slice();
    newData[productId].count = amount;
    props.setShopState(newData);
  }

  return (
    <div className="col-md">
      <h3>Products</h3>
      {props.shopState ? props.shopState.map(p => renderProduct(p)) : <></>}
    </div>
  );

}




