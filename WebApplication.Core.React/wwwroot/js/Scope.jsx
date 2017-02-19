﻿// The <Scope> component uses React's 'context' to pass down the component hierarchy the name of the back-end view model
// of the parent component, so that when the child component connects to its back-end view model, the child view model
// instance is created within the scope of the parent view model.
// The <Scope> component also provides the 'connect' function for a component to connect to the back-end view model and 
// injects properties and dispatch functions into the component.
var Scope = React.createClass({

   propTypes: { vm: React.PropTypes.string },
   contextTypes: { scoped: React.PropTypes.func },
   childContextTypes: {
      scoped: React.PropTypes.func.isRequired,
      connect: React.PropTypes.func.isRequired
   },
   scoped(vmId) {
      var scope = this.context.scoped ? this.context.scoped(this.props.vm) : this.props.vm;
      return scope ? scope + "." + vmId : vmId;
   },
   getChildContext() {
      return {
         scoped: vmId => this.scoped(vmId),
         connect: (component, vmId) => {
            component.vmId = this.scoped(vmId);
            component.vm = dotnetify.react.connect(component.vmId, () => component.state, state => component.setState(state));
            component.dispatch = state => component.vm.$dispatch(state);
            component.dispatchState = state => {
               component.setState(state);
               component.vm.$dispatch(state);
            }
            return window.vmStates[component.vmId];
         }
      };
   },
   render() {
      return this.props.children;
   }
});