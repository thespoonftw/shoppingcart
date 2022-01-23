import React from 'react';
import { Button } from 'reactstrap';

// All styling should be ideally moved into .css files
export function Checkout(props) {
  return (
    <div style={{marginTop: "50px"}}>
      <h3>Checkout</h3>
      <Button color="primary" style={{marginTop: "10px", width: "200px", height: "50px"}} onClick={() => props.setIsBasketOpen(true)}>
        Proceed to Payment
      </Button>
    </div>
    
  );
}
