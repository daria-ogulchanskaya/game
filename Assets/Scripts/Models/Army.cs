using System.Collections.Generic;
using System.Linq;

public class Army
{
    private readonly Dictionary<Unit.Type, int> _units;

    public IReadOnlyDictionary<Unit.Type, int> Units => _units;
    
    public Army()
    {
        _units = new Dictionary<Unit.Type, int>
        {
            [Unit.Type.Attack] = 0,
            [Unit.Type.Defence] = 0,
            [Unit.Type.Speed] = 0
        };
    }

    public void Add(Army army) => Add(army.Units);

    public void Add(IReadOnlyDictionary<Unit.Type, int> units)
    {
        foreach (var unit in units)
            Add(unit.Key, unit.Value);
    }

    public void Add(Unit.Type type, int amount) =>
        _units[type] += amount;

    public void Remove(Army army) => Remove(army.Units);

    public void Remove(IReadOnlyDictionary<Unit.Type, int> units)
    {
        foreach (var unit in units)
            _units[unit.Key] -= unit.Value;
    }

    public int Attack()
    {
        var attack = 0;
        foreach (var unit in Units)
            attack += (int) Settings.Units.Parameters(unit.Key).Attack * unit.Value;

        return attack;
    }

    public int Defence()
    {
        var defence = 0;
        foreach (var unit in Units)
            defence += (int) Settings.Units.Parameters(unit.Key).Attack * unit.Value;

        return defence;
    }

    public int Speed() =>
        Units
            .Select(x => Settings.Units.Parameters(x.Key))
            .Min(x => x.Speed);

    public int Count =>
        Units.Sum(x => x.Value);

    public bool Has(Army army) =>
        army.Units.All(x => x.Value <= Units[x.Key]);

    public int AttackUnits =>
        _units[Unit.Type.Attack];

    public int DefenceUnits =>
        _units[Unit.Type.Defence];

    public int SpeedUnits =>
        _units[Unit.Type.Speed];
}
