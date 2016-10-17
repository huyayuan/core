var BoxList = React.createClass({
    getInitialState: function () {
        return { boxList: []};
    },
    componentDidMount: function () {
        $.AMUI.progress.start();

        $.ajax({
            url: "home/getdata", success: function (data) {
                this.setState({ boxList: data });
                $.AMUI.progress.done();
            }.bind(this)
        });
    },
    onClick: function () {
        $.AMUI.progress.start();

        $.ajax({
            url: "home/getdata", success: function (data) {
                this.setState({ boxList: data });
                window._bd_share_main.init();
                $.AMUI.progress.done();
            }.bind(this)
        });
    },
    render: function () {
        var boxList = _.map(this.state.boxList, function (box) {
            return <Box key={box.Id} data={box} />
        });
        return (
	<div>
	    {boxList}
        <div id="change-content" className="w3-container w3-card-2 w3-white w3-round">
             <button id="refresh-btn" onClick={this.onClick} data-am-smooth-scroll="{position: 1}" className="w3-btn w3-white text-center am-btn am-btn-success"><i className="fa fa-wheelchair-alt"></i> <span className="button-word">传送</span> </button>
        </div>
	</div>
    );
    }
});
ReactDOM.render(
  <BoxList />,
  document.getElementById('content')
);