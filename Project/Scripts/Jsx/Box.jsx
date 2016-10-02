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

    var img = null;

    if(this.props.data.Type === 1)
    {
        img = <img src={this.props.data.Url} style={{}} className="w3-margin-bottom width-100"/>;
    }

    return (
        <div className="w3-container w3-card-2 w3-white w3-round w3-margin">
          <br/>
            <img src="Content/Images/Logo.jpg" alt="Avatar" className="w3-left w3-circle w3-margin-right" style={{width: 60}} />
              <h4>高能楼主</h4><br/>
              <hr className="w3-clear" />
                <p>{this.props.data.Title}</p>
                    {img}
                  <div className="w3-panel w3-pale-yellow w3-topbar w3-bottombar w3-border-yellow">
                    <p>

                        {this.props.data.Comments}

                    </p>
                  </div>
                  <button type="button" className="w3-btn w3-theme-d1 w3-margin-bottom"><i className="fa fa-thumbs-up"></i> {this.props.data.Rate} </button>
        </div>
    );
  }
});