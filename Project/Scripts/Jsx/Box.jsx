var Box = React.createClass({
  render: function() {
    return (
        <div className="w3-container w3-card-2 w3-white w3-round w3-margin">
          <br/>
            <img src="Content/Images/Logo.jpg" alt="Avatar" className="w3-left w3-circle w3-margin-right" style={{width: 60}} />
              <h4>John Doe</h4><br/>
              <hr className="w3-clear" />
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                <img src="Content/Images/img_lights.jpg" style={{flex: 1}} alt="Northern Lights" className="w3-margin-bottom"/>

                  <div className="w3-panel w3-leftbar">
                    <p>
                      <i className="fa fa-fire w3-xxlarge"></i><br/>
                      <i className="w3-serif w3-xlarge">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit ...
                      </i>
                    </p>
                  </div>
                  <button type="button" className="w3-btn w3-theme-d1 w3-margin-bottom"><i className="fa fa-thumbs-up"></i> 3.6万</button>

        </div>
    );
  }
});