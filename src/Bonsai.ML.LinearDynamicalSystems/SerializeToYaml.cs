using System;
using System.ComponentModel;
using System.Reactive.Linq;
using YamlDotNet.Serialization;

namespace Bonsai.ML.LinearDynamicalSystems
{
    /// <summary>
    /// Serializes a sequence of data model objects into YAML strings.
    /// </summary>
    [Combinator()]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Serializes a sequence of data model objects into YAML strings.")]
    public class SerializeToYaml
    {
        private IObservable<string> Process<T>(IObservable<T> source)
        {
            return Observable.Defer(() =>
            {
                var serializer = new SerializerBuilder().Build();
                return Observable.Select(source, value => serializer.Serialize(value)); 
            });
        }

        public IObservable<string> Process(IObservable<Kinematics.KFModelParameters> source)
        {
            return Process<Kinematics.KFModelParameters>(source);
        }

        public IObservable<string> Process(IObservable<Kinematics.Observation2D> source)
        {
            return Process<Kinematics.Observation2D>(source);
        }

        public IObservable<string> Process(IObservable<State> source)
        {
            return Process<State>(source);
        }

        public IObservable<string> Process(IObservable<StateComponent> source)
        {
            return Process<StateComponent>(source);
        }

        public IObservable<string> Process(IObservable<Kinematics.KinematicState> source)
        {
            return Process<Kinematics.KinematicState>(source);
        }

        public IObservable<string> Process(IObservable<Kinematics.KinematicComponent> source)
        {
            return Process<Kinematics.KinematicComponent>(source);
        }
    }
}
