import React from 'react';

// All styling should be ideally moved into .css files
// Hope you enjoyed the puns!
export function Header() {
  return (
    <div style={{textAlign: "center"}}>
      <h1 style={{color: "red", paddingTop: "10px"}}>TEST.CO</h1>          
      <h3 style={{color: "blue", marginTop: "-25px"}}>------------</h3>
      <p style={{paddingBottom: "10px", marginTop: "-20px"}}><b>Every bit counts!</b></p>
    </div>
  );
}
