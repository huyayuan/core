var Box = React.createClass({
  getDefaultProps: function(){
    return {
      data:{Title:"",
            Rate:"",
            Comments:"",
            Url:"",
            Id:""}
    };
  },
  render: function() {
    return (
        <div className="w3-container w3-card-2 w3-white w3-round w3-margin">
          <br/>
            <img src="Content/Images/Logo.jpg" alt="Avatar" className="w3-left w3-circle w3-margin-right" style={{width: 60}} />
              <h4>前方高能</h4><br/>
              <hr className="w3-clear" />
                <p>{this.props.data.Title}</p>
				  <img src={this.props.data.Url} className="w3-margin-bottom"/>

                  <div className="w3-panel w3-leftbar">
                    <p>
                      <i className="fa fa-fire w3-xxlarge"></i><br/>
                      <i className="w3-serif w3-xlarge">
                        {this.props.data.Comments}
                      </i>
                    </p>
                  </div>
                  <button type="button" className="w3-btn w3-theme-d1 w3-margin-bottom"><i className="fa fa-thumbs-up"></i> {this.props.data.Rate} </button>
        </div>
    );
  }
});