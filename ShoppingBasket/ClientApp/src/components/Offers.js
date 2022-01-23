import React from 'react';

// All styling should be ideally moved into .css files
// Could populate offers using an API to make website dynamic. (As has been done with products already)
export function Offers(props) {

  // renders a single offer
  function renderOffer(label) {
    return (
      <div style={{width: "100%", paddingTop: "2%", paddingLeft: "5%", paddingBottom: "1%", backgroundColor: "#ccc", marginTop: "10px" }}>
        <p>{label}</p>
      </div>
    );
  }

  return (
    <div>
      <h3>Offers</h3>
      {renderOffer("When you buy a cheese, get a second cheese free!")}
      {renderOffer("When you buy a Soup, you get a half price Bread!")}
      {renderOffer("Get a third off Butter!" )}
    </div>
  );

}
