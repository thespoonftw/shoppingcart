import React, { useEffect, useState } from 'react';
import { Modal, ModalHeader, ModalBody } from 'reactstrap';

// All styling should be ideally moved into .css files
export function Basket(props) {

  // Hook to update basket to update when modal opens
  const [basketData, setBasketData] = useState(null);

  // when modal opens, sends request to API to calculate new state of basket
  useEffect(
    () => {
      const fetchData = async(code) => {
        const response = await fetch('basket/' + code);
        const json = await response.json();
        setBasketData(json);
      }

      if (props.isBasketOpen) {
        const uriCode = getURICode(props.shopState);
        if (uriCode) {
          fetchData(uriCode);
        } else {
          setBasketData(null);
        } 
      }               
    }, 
    [props.isBasketOpen, props.shopState]
  )

  // render one item in the basket
  function renderBasketItem(item) {
    return <p key={item.description}>{item.amount}x {item.priceString} {item.description}</p>
  }

  // converts basket's state to string format to send to API: 0-2_1-4_2-1
  // first value in each pair is product ID, second value is amount of that product
  function getURICode(input) {
    if (!input) { return null; }    
    var stringBuilder = "";
    input.filter(p => p.count > 0).map(p =>
      stringBuilder += p.count + "x" + p.productId + "_"
      );
    return stringBuilder.slice(0, -1);
  }

  return (

      <Modal isOpen={props.isBasketOpen} size="xl">
        <ModalHeader toggle={() => props.setIsBasketOpen(false)}>
          Checkout
        </ModalHeader>
        <ModalBody>
          <div style={{width: "100%", paddingTop: "2%", paddingLeft: "5%", paddingBottom: "1%", backgroundColor: "#ccc", marginTop: "10px", minHeight: "100px" }}>
            { basketData ? 
              <div>
                { basketData.products.map(item => renderBasketItem(item)) }
                <p><b>Subtotal: </b>{basketData.subTotalString}</p> 
                <br></br>
                { basketData.discounts.map(item => renderBasketItem(item)) }
                <p><b>Total:</b> {basketData.totalString}</p>
              </div>        
            : 
            <p><b>Basket Is Empty</b></p>
            }
          </div>
        </ModalBody>
      </Modal>

      
  );

}
