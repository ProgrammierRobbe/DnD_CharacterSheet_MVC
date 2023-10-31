using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfRechner.Commands;
using WpfRechner.ViewModels;

namespace DnD_CharacterSheet_MVC.ViewModels
{
    internal class LogicViewModel : BaseViewModel
    {
        public struct FeatTraits
        {
            public string Features { get; set; }
            public string Traits { get; set; }
        }
        public struct ProfLang
        {
            public string Profciency { get; set; }
            public string Language { get; set; }
        }
        public struct AttacksSpells
        {
            public string AttackSpellName { get; set; }
            public string AttackBonus { get; set; }
            public string DamageType { get; set; }
        }
        public struct Equipment
        {
            public string EQName { get; set; }
            public string EQAttack { get; set; }
            public string EQDamage { get; set; }
        }
        public int Proficiency { get; set; }
        #region Strength getter / setter 
        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                CalcedStrength = Convert.ToInt32(Math.Floor((Convert.ToDouble(_strength) - 10) / 2));
            }
        }
        private int _calcedStrength;
        public int CalcedStrength
        {
            get { return _calcedStrength; }
            set
            {
                _calcedStrength = value;
                OnPropertyChanged(nameof(CalcedStrength));
            }
        }
        #endregion
        #region Dexterity getter / setter
        private int _dexterity;
        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                _dexterity = value;
                CalcedDexterity = Convert.ToInt32(Math.Floor((Convert.ToDouble(_dexterity) - 10) / 2));
            }
        }
        private int _calcedDexterity;
        public int CalcedDexterity
        {
            get { return _calcedDexterity; }
            set
            {
                _calcedDexterity = value;
                OnPropertyChanged(nameof(CalcedDexterity));
            }
        }
        #endregion
        #region Constitution getter / setter
        private int _constitution;
        public int Constitution
        {
            get { return _constitution; }
            set
            {
                _constitution = value;
                CalcedConstitution = Convert.ToInt32(Math.Floor((Convert.ToDouble(_constitution) - 10) / 2));
            }
        }
        private int _calcedConstitution;
        public int CalcedConstitution
        {
            get { return _calcedConstitution; }
            set
            {
                _calcedConstitution = value;
                OnPropertyChanged(nameof(CalcedConstitution));
            }
        }
        #endregion
        #region Intelligence getter / setter 
        private int _intelligence;
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
                CalcedIntelligence = Convert.ToInt32(Math.Floor((Convert.ToDouble(_intelligence) - 10) / 2));
            }
        }
        private int _calcedIntelligence;
        public int CalcedIntelligence
        {
            get { return _calcedIntelligence; }
            set
            {
                _calcedIntelligence = value;
                OnPropertyChanged(nameof(CalcedIntelligence));
            }
        }
        #endregion
        #region Wisdom getter / setter 
        private int _wisdom;
        public int Wisdom
        {
            get { return _wisdom; }
            set
            {
                _wisdom = value;
                CalcedWisdom = Convert.ToInt32(Math.Floor((Convert.ToDouble(_wisdom) - 10) / 2));
            }
        }
        private int _calcedWisdom;
        public int CalcedWisdom
        {
            get { return _calcedWisdom; }
            set
            {
                _calcedWisdom = value;
                OnPropertyChanged(nameof(CalcedWisdom));
            }
        }
        #endregion
        #region Charisma getter / setter
        private int _charisma;
        public int Charisma
        {
            get { return _charisma; }
            set
            {
                _charisma = value;
                CalcedCharisma = Convert.ToInt32(Math.Floor((Convert.ToDouble(_charisma) - 10) / 2));
            }
        }
        private int _calcedCharisma;
        public int CalcedCharisma
        {
            get { return _calcedCharisma; }
            set
            {
                _calcedCharisma = value;
                OnPropertyChanged(nameof(CalcedCharisma));
            }
        }
        #endregion
        #region StrengthSavingThrow
        private int _strengthST;

        public int StrengthST
        {
            get { return _strengthST; }
            set
            {
                _strengthST = value;
                CalcedStrengthST = Convert.ToInt32(Proficiency + CalcedStrength);
            }
        }
        private int _calcedStrengthST;
        public int CalcedStrengthST
        {
            get { return _calcedStrengthST; }
            set
            {
                _calcedStrengthST = value;
                OnPropertyChanged(nameof(CalcedStrengthST));
            }
        }
        #endregion
        #region DexteritySavingThrow
        private int _dexterityST;
        public int DexterityST
        {
            get { return _dexterityST; }
            set
            {
                _dexterityST = value;
                CalcedDexterityST = Convert.ToInt32(Proficiency + CalcedDexterity);
            }
        }
        private int _calcedDexterityST;
        public int CalcedDexterityST
        {
            get { return _calcedDexterityST; }
            set
            {
                _calcedDexterityST = value;
                OnPropertyChanged(nameof(CalcedDexterityST));
            }
        }
        #endregion
        #region ConstitutionSavingThrow
        private int _constitutionST;
        public int ConstitutionST
        {
            get { return _constitutionST; }
            set
            {
                _constitutionST = value;
                CalcedConstitutionST = Convert.ToInt32(Proficiency + CalcedConstitution);
            }
        }
        private int _calcedConstitutionST;
        public int CalcedConstitutionST
        {
            get { return _calcedConstitutionST; }
            set
            {
                _calcedConstitutionST = value;
                OnPropertyChanged(nameof(CalcedConstitutionST));
            }
        }
        #endregion
        #region IntelligenceSavingThrow
        private int _intelligenceST;
        public int IntelligenceST
        {
            get { return _intelligenceST; }
            set
            {
                _intelligenceST = value;
                CalcedIntelligenceST = Convert.ToInt32(Proficiency + CalcedIntelligence);
            }
        }

        private int _calcedIntelligenceST;
        public int CalcedIntelligenceST
        {
            get { return _calcedIntelligenceST; }
            set
            {
                _calcedIntelligenceST = value;
                OnPropertyChanged(nameof(CalcedIntelligenceST));
            }
        }
        #endregion
        #region WisdomSavingThrow
        private int _wisdomST;
        public int WisdomST
        {
            get { return _wisdomST; }
            set
            {
                _wisdomST = value;
                CalcedWisdomST = Convert.ToInt32(Proficiency + CalcedWisdom);
            }
        }

        private int _calcedWisdomST;
        public int CalcedWisdomST
        {
            get { return _calcedWisdom; }
            set
            {
                _calcedWisdom = value;
                OnPropertyChanged(nameof(CalcedWisdomST));
            }
        }
        #endregion
        #region CharismaSavingThrow
        private int _charismaST;
        public int CharismaST
        {
            get { return _charismaST; }
            set
            {
                _charismaST = value;
                CalcedCharismaST = Convert.ToInt32(Proficiency + CalcedCharisma);
            }
        }

        private int _calcedCharismaST;
        public int CalcedCharismaST
        {
            get { return _calcedCharismaST; }
            set
            {
                _calcedCharismaST = value;
                OnPropertyChanged(nameof(CalcedCharismaST));
            }
        }
        #endregion

        #region Equipment
        private ObservableCollection<Equipment> _equipmentList = new ObservableCollection<Equipment>();
        public ObservableCollection<Equipment> EquipmentList
        {
            get { return _equipmentList; }
            set
            {
                _equipmentList = value;
                OnPropertyChanged(nameof(EquipmentList));
            }
        }
        public ICommand AddEquipment { get => _addEquipment; }
        private RelayCommand _addEquipment;
        private string _EQName;
        public string EQName
        {
            get =>  _EQName;
            set { _EQName = value;
            _addEquipment?.RaiseCanExecuteChanged();}
        }
        private string _EQAttack;
        public string EQNameAttack
        {
            get=> _EQAttack;
            set
            {
                _EQAttack = value;
                _addEquipment?.RaiseCanExecuteChanged();
            }
        }
        private string _EQDamage;
        public string EQDamage
        {
            get => _EQDamage;
            set
            {
                _EQDamage= value;
                _addEquipment?.RaiseCanExecuteChanged();
            }
        }
        private void AddEquipmentMethod()
        {
            EquipmentList.Add(new() { EQName = EQName, EQAttack = EQNameAttack, EQDamage = EQDamage });
        }

        #endregion
        #region Attacks Spellcasting List
        private ObservableCollection<AttacksSpells> _attacksSpellsList = new ObservableCollection<AttacksSpells>();
        public ObservableCollection<AttacksSpells> AttackSpellsList
        {
            get { return _attacksSpellsList; }
            set
            {
                _attacksSpellsList = value;
                OnPropertyChanged(nameof(AttackSpellsList));
            }
        }
        public ICommand AddAttacks_Spells { get => _addAttack_Spell; }
        private RelayCommand _addAttack_Spell;
        private string _attackName;
        public string AttackName
        {
            get => _attackName;
            set
            {
                _attackName = value;
                _addAttack_Spell.RaiseCanExecuteChanged();
            }
        }
        private string _attackBonus;
        public string AttackBonus
        {
            get => _attackBonus;
            set
            {
                _attackBonus = value;
                _addAttack_Spell.RaiseCanExecuteChanged();
            }
        }
        private string _damageType;
        public string DamageType
        {
            get=> _damageType;
            set
            {
                _damageType = value;
                _addAttack_Spell?.RaiseCanExecuteChanged();
            }
        }
        private void AddAttack_SpellMethod()
        {
            AttackSpellsList.Add(new() { AttackSpellName = AttackName, AttackBonus = AttackBonus, DamageType = DamageType });
        }
        
        #endregion
        #region Languages Proficiency List
        private ObservableCollection<ProfLang> _prof_langsList = new ObservableCollection<ProfLang>();
        public ObservableCollection<ProfLang> Prof_LangsList
        {
            get { return _prof_langsList; }
            set
            {
                _prof_langsList = value;
                OnPropertyChanged(nameof(Prof_LangsList));
            }
        }
        public ICommand AddLanguage_Proficiency { get => _addLanguage_Proficinecy; }
        private RelayCommand _addLanguage_Proficinecy;
        private string _proficiency;
        public string Proficiency_
        {
            get => _proficiency; 
            set { _proficiency = value;
                _addLanguage_Proficinecy.RaiseCanExecuteChanged();
            }
        }
        private string _language;
        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                _addLanguage_Proficinecy.RaiseCanExecuteChanged();
            }
        }
        private void AddLanguage_ProficiencyMethod()
        {
            Prof_LangsList.Add(new() { Language = Language, Profciency = Proficiency_ });
        }
        #endregion
        #region Features Traits ListView
        public ObservableCollection<FeatTraits> _features_traitsList = new ObservableCollection<FeatTraits>();
        public ObservableCollection<FeatTraits> Features_TraitsList
        {
            get { return _features_traitsList; }
            set
            {
                _features_traitsList = value;
                OnPropertyChanged(nameof(Features_TraitsList));
            }
        }
        public ICommand AddFeature_Trait { get => _addfeature_trait; }
        private RelayCommand _addfeature_trait;
        private string _features;

        public string Features
        {
            get { return _features; }
            set { _features = value; _addfeature_trait.RaiseCanExecuteChanged(); }
        }
        private string _traits;

        public string Traits
        {
            get { return _traits; }
            set { _traits = value; _addfeature_trait.RaiseCanExecuteChanged(); }
        }

        private void AddFeature_TraitMethod()
        {
            Features_TraitsList.Add(new FeatTraits() { Features = Features, Traits = Traits });
        }
        #endregion
        public LogicViewModel()
        {
            _addfeature_trait = new RelayCommand(AddFeature_TraitMethod, () => Features != null && Traits != null);
            _addLanguage_Proficinecy = new RelayCommand(AddLanguage_ProficiencyMethod, () => Language != null && Proficiency_ != null);
            _addAttack_Spell = new RelayCommand(AddAttack_SpellMethod, () => AttackName != null && AttackBonus != null && DamageType != null);
            _addEquipment = new RelayCommand(AddEquipmentMethod, () => EQName != null && EQNameAttack != null && EQDamage != null);
        }
    }



}