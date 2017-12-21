using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Engine.Actions {
    public class ActionQueue : MonoBehaviour {

        /// <summary>
        /// The actions currently attached to the combatant. This queue represents the order of execution.
        /// </summary>
        private LinkedList<ActorAction> actions;
        public int ActionCount {
            get { return actions.Count; }
        }

        /// <summary>
        /// The action currently being executed.
        /// </summary>
        public ActorAction CurrentAction {
            get {
                if (actions.Count > 0)
                    return actions.First.Value;
                else
                    return null;
            }
        }

        void Awake() {
            actions = new LinkedList<ActorAction>();
        }

        void Update() {
            if (actions.Count > 0) {
                if (actions.First.Value.Complete == true) {
                    ActorAction action = actions.First.Value;
                    actions.RemoveFirst();
                    Destroy(action);

                    // Enable the next action in the queue
                    if (actions.Count > 0) {
                        actions.First.Value.enabled = true;
                    }
                }

            }
        }

        /// <summary>
        /// Add an action to the end of the queue.
        /// </summary>
        /// <param name="action">The action to add to the end of the queue.</param>
        public void AddAction(ActorAction action) {
            if (action != null)
                this.actions.AddLast(action);
        }

        public void AddToFront(ActorAction action) {

            if(action != null) {

                if (this.actions.First != null) {
                    this.actions.First.Value.enabled = false;
                }

                this.actions.AddFirst(action);
                this.actions.First.Value.enabled = true;
            }
        }

        /// <summary>
        /// Add multiple actions to the end of the queue. 
        /// </summary>
        /// <param name="actionsToQueue">The actions to add to the end of the queue. The order in the array defines execution order.</param>
        public void AddActions(ActorAction[] actionsToQueue) {
            if (actionsToQueue != null) {
                bool noPendingActions;

                if (this.actions.Count == 0) {
                    noPendingActions = true;
                }
                else {
                    noPendingActions = false;
                }

                foreach (ActorAction Action in actionsToQueue) {
                    this.actions.AddLast(Action);
                }

                //if (noPendingActions) {
                //    this.actions.Peek().enabled = true;
                //}
            }
        }

        /// <summary>
        /// Removes all currently queued actions from the queue, and replaces them with a new action.
        /// </summary>
        /// <param name="action">The action to perform immediately, cancelling all other actions.</param>
        public void SetAction(ActorAction action) {

            foreach (ActorAction queuedAction in actions) {
                Destroy(queuedAction);
            }

            actions.Clear();
            actions.AddLast(action);

            if (actions.Count > 0)
                actions.First.Value.enabled = true;
        }

        /// <summary>
        ///  Removes all currently queued actions from the queue, and replaces them with a new series of actions.
        /// </summary>
        /// <param name="actionsToQueue">The actions to perform immediatelly, cancelling all other actions.</param>
        public void SetActions(ActorAction[] actionsToQueue) {
            try {

                foreach (ActorAction queuedAction in actions) {
                    Destroy(queuedAction);
                }

                actions.Clear();

                foreach (ActorAction action in actionsToQueue) {
                    actions.AddLast(action);
                }

                if (actions.Count > 0)
                    actions.First.Value.enabled = true;
            }
            catch (Exception e) {
                Debug.Log("Null combat action passed.");
            }
        }
    }
}
