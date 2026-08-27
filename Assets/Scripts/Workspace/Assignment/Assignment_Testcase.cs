using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Reflection;

using Assignment.StudentSolution;
using LCT01 = Assignment.StudentSolution.LCT01;
using LCT02 = Assignment.StudentSolution.LCT02;
using LCT03 = Assignment.StudentSolution.LCT03;
using LCT04 = Assignment.StudentSolution.LCT04;
using LCT05 = Assignment.StudentSolution.LCT05;

namespace Assignment
{
    public class Assignment_Testcase
    {
        private const string namespaceName = "Assignment.StudentSolution";
        // private const string namespaceName = "Assignment03.FinalSolution";

        private readonly string[] expectedClasses = {
            "Entity", "Player", "Enemy", "MeleeEnemy", "RangeEnemy", "Troll", "Orc",
            "Archer", "Mage", "NPC", "Item", "Equipment", "Weapon", "Sword", "Bow",
            "Staff", "Armor", "Potion"
        };

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void Teardown()
        {

        }
        
        #region Assignment

        #region Test Group 1: Contains all classes in diagram

        [Category("Assignment")]
        [Test(Description = "Test if all expected classes exist in the namespace")]
        public void AS01_TestAllClassesExist()
        {
            var assembly = Assembly.GetAssembly(typeof(Entity));
            var namespaceTypes = assembly.GetTypes()
                .Where(t => t.Namespace == namespaceName)
                .Select(t => t.Name)
                .ToArray();

            foreach (var expectedClass in expectedClasses)
            {
                Assert.Contains(expectedClass, namespaceTypes,
                    $"Class {expectedClass} is missing from {namespaceName} namespace");
            }

            Assert.AreEqual(expectedClasses.Length, namespaceTypes.Length,
                "Number of classes in namespace Assignment't match expected count");
        }

        #endregion

        #region Test Group 2: Each class has fully implemented members


        [Category("Assignment")]
        [Test(Description = "Test Entity class members including fields and methods with correct access modifiers")]
        public void AS02_TestEntityMembers()
        {
            var entityType = typeof(Entity);

            // Test fields
            var nameField = entityType.GetField("name", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(nameField, "public name field is missing");
            Assert.AreEqual(typeof(string), nameField.FieldType);

            var positionField = entityType.GetField("position", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(positionField, "private position field is missing");
            Assert.AreEqual(typeof(Vector3), positionField.FieldType);
            Assert.IsTrue(positionField.IsPrivate, "Entity.position should be private");

            var healthField = entityType.GetField("health", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(healthField, "protected health field is missing");
            Assert.AreEqual(typeof(int), healthField.FieldType);
            Assert.IsTrue(healthField.IsFamily, "Entity.health should be protected");

            // Test methods
            var updateMethod = entityType.GetMethod("Update", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(updateMethod, "public Update(...) method is missing");
            Assert.IsTrue(updateMethod.IsVirtual, "Entity.Update should be virtual");

            var takeDamageMethod = entityType.GetMethod("TakeDamage", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(takeDamageMethod, "protected TakeDamage(...) method is missing");
            Assert.IsTrue(takeDamageMethod.IsFamily, "Entity.TakeDamage should be protected");
            Assert.IsTrue(takeDamageMethod.IsVirtual, "Entity.TakeDamage should be virtual");

            var moveMethod = entityType.GetMethod("Move", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(moveMethod, "private Move(...) method is missing");
            Assert.IsTrue(moveMethod.IsPrivate, "Entity.Move should be private");
        }


        [Category("Assignment")]
        [Test(Description = "Test Player class members including score field and item collection methods")]
        public void AS03_TestPlayerMembers()
        {
            var playerType = typeof(Player);

            // Test fields
            var scoreField = playerType.GetField("score", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(scoreField, "public score field is missing");
            Assert.AreEqual(typeof(int), scoreField.FieldType);

            var itemsField = playerType.GetField("items", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(itemsField, "private items field is missing");
            Assert.AreEqual(typeof(Item[]), itemsField.FieldType);
            Assert.IsTrue(itemsField.IsPrivate, "Player.items should be private");

            // Test methods
            var collectItemMethod = playerType.GetMethod("CollectItem", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(collectItemMethod, "public CollectItem(...) method is missing");

            var levelUpMethod = playerType.GetMethod("LevelUp", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(levelUpMethod, "protected LevelUp(...) method is missing");
            Assert.IsTrue(levelUpMethod.IsFamily, "Player.LevelUp should be protected");
        }


        [Category("Assignment")]
        [Test(Description = "Test Enemy class members including damage field and attack/patrol methods")]
        public void AS04_TestEnemyMembers()
        {
            var enemyType = typeof(Enemy);

            // Test fields
            var damageField = enemyType.GetField("damage", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(damageField, "public damage field is missing");
            Assert.AreEqual(typeof(int), damageField.FieldType);

            var aiLevelField = enemyType.GetField("aiLevel", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(aiLevelField, "protected aiLevel field is missing");
            Assert.AreEqual(typeof(int), aiLevelField.FieldType);
            Assert.IsTrue(aiLevelField.IsFamily, "Enemy.aiLevel should be protected");

            // Test methods
            var attackMethod = enemyType.GetMethod("Attack", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(attackMethod, "public Attack(...) method is missing");
            Assert.IsTrue(attackMethod.IsVirtual, "Enemy.Attack should be virtual");

            var patrolMethod = enemyType.GetMethod("Patrol", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(patrolMethod, "protected Patrol(...) method is missing");
            Assert.IsTrue(patrolMethod.IsFamily, "Enemy.Patrol should be protected");
            Assert.IsTrue(patrolMethod.IsVirtual, "Enemy.Patrol should be virtual");
        }


        [Category("Assignment")]
        [Test(Description = "Test Item class members including name field and virtual Use method")]
        public void AS05_TestItemMembers()
        {
            var itemType = typeof(Item);

            // Test fields
            var nameField = itemType.GetField("name", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(nameField, "public name field is missing");
            Assert.AreEqual(typeof(string), nameField.FieldType);

            var valueField = itemType.GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(valueField, "private value field is missing");
            Assert.AreEqual(typeof(int), valueField.FieldType);
            Assert.IsTrue(valueField.IsPrivate, "Item.value should be private");

            // Test methods
            var useMethod = itemType.GetMethod("Use", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(useMethod, "public Use(...) method is missing");
            Assert.IsTrue(useMethod.IsVirtual, "Item.Use should be virtual");
        }


        [Category("Assignment")]
        [Test(Description = "Test Weapon class members including attackPower field and virtual DealDamage method")]
        public void AS06_TestWeaponMembers()
        {
            var weaponType = typeof(Weapon);

            // Test fields
            var attackPowerField = weaponType.GetField("attackPower", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(attackPowerField, "public attackPower field is missing");
            Assert.AreEqual(typeof(int), attackPowerField.FieldType);

            // Test methods
            var dealDamageMethod = weaponType.GetMethod("DealDamage", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(dealDamageMethod, "public DealDamage(...) method is missing");
            Assert.IsTrue(dealDamageMethod.IsVirtual, "Weapon.DealDamage should be virtual");
        }


        [Category("Assignment")]
        [Test(Description = "Test Sword class members including bladeLength field and overridden Equip/DealDamage methods")]
        public void AS07_TestSwordMembers()
        {
            var swordType = typeof(Sword);

            // Test fields
            var bladeLengthField = swordType.GetField("bladeLength", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(bladeLengthField, "public bladeLength field is missing");
            Assert.AreEqual(typeof(int), bladeLengthField.FieldType);

            // Test methods
            var slashMethod = swordType.GetMethod("Slash", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(slashMethod, "public Slash(...) method is missing");

            var equipMethod = swordType.GetMethod("Equip", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(equipMethod, "public Equip(...) method is missing");
            Assert.IsTrue(equipMethod.IsVirtual && equipMethod.GetBaseDefinition().DeclaringType != swordType, "Sword.Equip should be override");

            var dealDamageMethod = swordType.GetMethod("DealDamage", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(dealDamageMethod, "public DealDamage(...) method is missing");
            Assert.IsTrue(dealDamageMethod.IsVirtual && dealDamageMethod.GetBaseDefinition().DeclaringType != swordType, "Sword.DealDamage should be override");
        }


        [Category("Assignment")]
        [Test(Description = "Test Bow class members including range field and overridden Equip/DealDamage methods")]
        public void AS08_TestBowMembers()
        {
            var bowType = typeof(Bow);

            // Test fields
            var rangeField = bowType.GetField("range", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(rangeField, "public range field is missing");
            Assert.AreEqual(typeof(int), rangeField.FieldType);

            // Test methods
            var shootMethod = bowType.GetMethod("Shoot", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(shootMethod, "public Shoot(...) method is missing");

            var equipMethod = bowType.GetMethod("Equip", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(equipMethod, "public Equip(...) method is missing");
            Assert.IsTrue(equipMethod.IsVirtual && equipMethod.GetBaseDefinition().DeclaringType != bowType, "Bow.Equip should be override");

            var dealDamageMethod = bowType.GetMethod("DealDamage", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(dealDamageMethod, "public DealDamage(...) method is missing");
            Assert.IsTrue(dealDamageMethod.IsVirtual && dealDamageMethod.GetBaseDefinition().DeclaringType != bowType, "Bow.DealDamage should be override");
        }


        [Category("Assignment")]
        [Test(Description = "Test Staff class members including magicPower field and overridden Equip/DealDamage methods")]
        public void AS09_TestStaffMembers()
        {
            var staffType = typeof(Staff);

            // Test fields
            var magicPowerField = staffType.GetField("magicPower", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(magicPowerField, "public magicPower field is missing");
            Assert.AreEqual(typeof(int), magicPowerField.FieldType);

            // Test methods
            var castSpellMethod = staffType.GetMethod("CastSpell", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(castSpellMethod, "public CastSpell(...) method is missing");

            var equipMethod = staffType.GetMethod("Equip", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(equipMethod, "public Equip(...) method is missing");
            Assert.IsTrue(equipMethod.IsVirtual && equipMethod.GetBaseDefinition().DeclaringType != staffType, "Staff.Equip should be override");

            var dealDamageMethod = staffType.GetMethod("DealDamage", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(dealDamageMethod, "public DealDamage(...) method is missing");
            Assert.IsTrue(dealDamageMethod.IsVirtual && dealDamageMethod.GetBaseDefinition().DeclaringType != staffType, "Staff.DealDamage should be override");
        }


        [Category("Assignment")]
        [Test(Description = "Test Armor class members including defense field and overridden Equip method")]
        public void AS10_TestArmorMembers()
        {
            var armorType = typeof(Armor);

            // Test fields
            var defenseField = armorType.GetField("defense", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(defenseField, "public defense field is missing");
            Assert.AreEqual(typeof(int), defenseField.FieldType);

            // Test methods
            var equipMethod = armorType.GetMethod("Equip", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(equipMethod, "public Equip(...) method is missing");
            Assert.IsTrue(equipMethod.IsVirtual && equipMethod.GetBaseDefinition().DeclaringType != armorType, "Armor.Equip should be override");
        }


        [Category("Assignment")]
        [Test(Description = "Test Potion class members including healingAmount field and overridden Use method")]
        public void AS11_TestPotionMembers()
        {
            var potionType = typeof(Potion);

            // Test fields
            var healingAmountField = potionType.GetField("healingAmount", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(healingAmountField, "public healingAmount field is missing");
            Assert.AreEqual(typeof(int), healingAmountField.FieldType);

            // Test methods
            var useMethod = potionType.GetMethod("Use", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(useMethod, "public Use(...) method is missing");
            Assert.IsTrue(useMethod.IsVirtual && useMethod.GetBaseDefinition().DeclaringType != potionType, "Potion.Use should be override");
        }


        [Category("Assignment")]
        [Test(Description = "Test NPC class members including dialogue field and virtual Interact method")]
        public void AS12_TestNPCMembers()
        {
            var npcType = typeof(NPC);

            // Test fields
            var dialogueField = npcType.GetField("dialogue", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(dialogueField, "public dialogue field is missing");
            Assert.AreEqual(typeof(string), dialogueField.FieldType);

            var isFriendlyField = npcType.GetField("isFriendly", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(isFriendlyField, "private isFriendly field is missing");
            Assert.AreEqual(typeof(bool), isFriendlyField.FieldType);
            Assert.IsTrue(isFriendlyField.IsPrivate, "NPC.isFriendly should be private");

            // Test methods
            var interactMethod = npcType.GetMethod("Interact", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(interactMethod, "public Interact(...) method is missing");
            Assert.IsTrue(interactMethod.IsVirtual, "NPC.Interact should be virtual");
        }


        [Category("Assignment")]
        [Test(Description = "Test MeleeEnemy class members including strength field and overridden Attack method")]
        public void AS13_TestMeleeEnemyMembers()
        {
            var meleeEnemyType = typeof(MeleeEnemy);

            // Test fields
            var strengthField = meleeEnemyType.GetField("strength", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(strengthField, "public strength field is missing");
            Assert.AreEqual(typeof(int), strengthField.FieldType);

            // Test methods
            var attackMethod = meleeEnemyType.GetMethod("Attack", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(attackMethod, "public Attack(...) method is missing");
            Assert.IsTrue(attackMethod.IsVirtual && attackMethod.GetBaseDefinition().DeclaringType != meleeEnemyType, "MeleeEnemy.Attack should be override");
        }


        [Category("Assignment")]
        [Test(Description = "Test RangeEnemy class members including range field and overridden Attack method")]
        public void AS14_TestRangeEnemyMembers()
        {
            var rangeEnemyType = typeof(RangeEnemy);

            // Test fields
            var rangeField = rangeEnemyType.GetField("range", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(rangeField, "public range field is missing");
            Assert.AreEqual(typeof(int), rangeField.FieldType);

            // Test methods
            var attackMethod = rangeEnemyType.GetMethod("Attack", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(attackMethod, "public Attack(...) method is missing");
            Assert.IsTrue(attackMethod.IsVirtual && attackMethod.GetBaseDefinition().DeclaringType != rangeEnemyType, "RangeEnemy.Attack should be override");
        }


        [Category("Assignment")]
        [Test(Description = "Test Troll class members including regenerationRate field and Regenerate method")]
        public void AS15_TestTrollMembers()
        {
            var trollType = typeof(Troll);

            // Test fields
            var regenerationRateField = trollType.GetField("regenerationRate", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(regenerationRateField, "public regenerationRate field is missing");
            Assert.AreEqual(typeof(int), regenerationRateField.FieldType);

            // Test methods
            var regenerateMethod = trollType.GetMethod("Regenerate", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(regenerateMethod, "public Regenerate(...) method is missing");
        }


        [Category("Assignment")]
        [Test(Description = "Test Orc class members including rageLevel field and Enrage method")]
        public void AS16_TestOrcMembers()
        {
            var orcType = typeof(Orc);

            // Test fields
            var rageLevelField = orcType.GetField("rageLevel", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(rageLevelField, "public rageLevel field is missing");
            Assert.AreEqual(typeof(int), rageLevelField.FieldType);

            // Test methods
            var enrageMethod = orcType.GetMethod("Enrage", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(enrageMethod, "public Enrage(...) method is missing");
        }


        [Category("Assignment")]
        [Test(Description = "Test Archer class members including accuracy field and overridden Attack method")]
        public void AS17_TestArcherMembers()
        {
            var archerType = typeof(Archer);

            // Test fields
            var accuracyField = archerType.GetField("accuracy", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(accuracyField, "public accuracy field is missing");
            Assert.AreEqual(typeof(int), accuracyField.FieldType);

            // Test methods
            var attackMethod = archerType.GetMethod("Attack", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(attackMethod, "public Attack(...) method is missing");
            Assert.IsTrue(attackMethod.IsVirtual && attackMethod.GetBaseDefinition().DeclaringType != archerType, "Archer.Attack should be override");

            var aimAndShootMethod = archerType.GetMethod("AimAndShoot", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(aimAndShootMethod, "public AimAndShoot(...) method is missing");
        }


        [Category("Assignment")]
        [Test(Description = "Test Mage class members including mana field and overridden Attack method")]
        public void AS18_TestMageMembers()
        {
            var mageType = typeof(Mage);

            // Test fields
            var manaField = mageType.GetField("mana", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(manaField, "public mana field is missing");
            Assert.AreEqual(typeof(int), manaField.FieldType);

            // Test methods
            var attackMethod = mageType.GetMethod("Attack", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(attackMethod, "public Attack(...) method is missing");
            Assert.IsTrue(attackMethod.IsVirtual && attackMethod.GetBaseDefinition().DeclaringType != mageType, "Mage.Attack should be override");

            var castSpellMethod = mageType.GetMethod("CastSpell", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(castSpellMethod, "public CastSpell(...) method is missing");
        }

        [Category("Assignment")]
        [Test(Description = "Test Equipment class members including virtual Equip method")]
        public void AS19_TestEquipmentMembers()
        {
            var equipmentType = typeof(Equipment);

            // Test methods
            var equipMethod = equipmentType.GetMethod("Equip", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(equipMethod, "public Equip(...) method is missing");
            Assert.IsTrue(equipMethod.IsVirtual, "Equipment.Equip should be virtual");
        }

        #endregion

        #region Test Group 3: All classes have correct inheritance relationships


        [Category("Assignment")]
        [Test(Description = "Test all inheritance relationships between classes in the hierarchy")]
        public void AS20_TestInheritanceRelationships()
        {
            // Test Entity inheritance
            Assert.IsTrue(typeof(Player).IsSubclassOf(typeof(Entity)), "Player should inherit from Entity");
            Assert.IsTrue(typeof(Enemy).IsSubclassOf(typeof(Entity)), "Enemy should inherit from Entity");
            Assert.IsTrue(typeof(NPC).IsSubclassOf(typeof(Entity)), "NPC should inherit from Entity");

            // Test Enemy inheritance hierarchy
            Assert.IsTrue(typeof(MeleeEnemy).IsSubclassOf(typeof(Enemy)), "MeleeEnemy should inherit from Enemy");
            Assert.IsTrue(typeof(RangeEnemy).IsSubclassOf(typeof(Enemy)), "RangeEnemy should inherit from Enemy");
            Assert.IsTrue(typeof(Troll).IsSubclassOf(typeof(MeleeEnemy)), "Troll should inherit from MeleeEnemy");
            Assert.IsTrue(typeof(Orc).IsSubclassOf(typeof(MeleeEnemy)), "Orc should inherit from MeleeEnemy");
            Assert.IsTrue(typeof(Archer).IsSubclassOf(typeof(RangeEnemy)), "Archer should inherit from RangeEnemy");
            Assert.IsTrue(typeof(Mage).IsSubclassOf(typeof(RangeEnemy)), "Mage should inherit from RangeEnemy");

            // Test Item inheritance hierarchy
            Assert.IsTrue(typeof(Equipment).IsSubclassOf(typeof(Item)), "Equipment should inherit from Item");
            Assert.IsTrue(typeof(Potion).IsSubclassOf(typeof(Item)), "Potion should inherit from Item");
            Assert.IsTrue(typeof(Weapon).IsSubclassOf(typeof(Equipment)), "Weapon should inherit from Equipment");
            Assert.IsTrue(typeof(Armor).IsSubclassOf(typeof(Equipment)), "Armor should inherit from Equipment");
            Assert.IsTrue(typeof(Sword).IsSubclassOf(typeof(Weapon)), "Sword should inherit from Weapon");
            Assert.IsTrue(typeof(Bow).IsSubclassOf(typeof(Weapon)), "Bow should inherit from Weapon");
            Assert.IsTrue(typeof(Staff).IsSubclassOf(typeof(Weapon)), "Staff should inherit from Weapon");
        }

        #endregion

        #region Test Group 4: Access Modifier Verification


        [Category("Assignment")]
        [Test(Description = "Test access modifiers for all class members (public, private, protected)")]
        public void AS21_TestAccessModifiers()
        {
            // Test Entity access modifiers
            var entityType = typeof(Entity);
            var nameField = entityType.GetField("name");
            Assert.IsTrue(nameField.IsPublic, "Entity.name should be public");

            var positionField = entityType.GetField("position", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(positionField.IsPrivate, "Entity.position should be private");

            var healthField = entityType.GetField("health", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(healthField.IsFamily, "Entity.health should be protected");

            var updateMethod = entityType.GetMethod("Update");
            Assert.IsTrue(updateMethod.IsPublic, "Entity.Update should be public");

            var takeDamageMethod = entityType.GetMethod("TakeDamage", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(takeDamageMethod.IsFamily, "Entity.TakeDamage should be protected");

            var moveMethod = entityType.GetMethod("Move", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(moveMethod.IsPrivate, "Entity.Move should be private");

            // Test Player access modifiers
            var playerType = typeof(Player);
            var scoreField = playerType.GetField("score");
            Assert.IsTrue(scoreField.IsPublic, "Player.score should be public");

            var itemsField = playerType.GetField("items", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(itemsField.IsPrivate, "Player.items should be private");

            var collectItemMethod = playerType.GetMethod("CollectItem");
            Assert.IsTrue(collectItemMethod.IsPublic, "Player.CollectItem should be public");

            var levelUpMethod = playerType.GetMethod("LevelUp", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(levelUpMethod.IsFamily, "Player.LevelUp should be protected");

            // Test Enemy access modifiers
            var enemyType = typeof(Enemy);
            var damageField = enemyType.GetField("damage");
            Assert.IsTrue(damageField.IsPublic, "Enemy.damage should be public");

            var aiLevelField = enemyType.GetField("aiLevel", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(aiLevelField.IsFamily, "Enemy.aiLevel should be protected");

            var attackMethod = enemyType.GetMethod("Attack");
            Assert.IsTrue(attackMethod.IsPublic, "Enemy.Attack should be public");

            var patrolMethod = enemyType.GetMethod("Patrol", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(patrolMethod.IsFamily, "Enemy.Patrol should be protected");

            // Test Item access modifiers
            var itemType = typeof(Item);
            var itemNameField = itemType.GetField("name");
            Assert.IsTrue(itemNameField.IsPublic, "Item.name should be public");

            var valueField = itemType.GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(valueField.IsPrivate, "Item.value should be private");

            var useMethod = itemType.GetMethod("Use");
            Assert.IsTrue(useMethod.IsPublic, "Item.Use should be public");

            // Test NPC access modifiers
            var npcType = typeof(NPC);
            var dialogueField = npcType.GetField("dialogue");
            Assert.IsTrue(dialogueField.IsPublic, "NPC.dialogue should be public");

            var isFriendlyField = npcType.GetField("isFriendly", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsTrue(isFriendlyField.IsPrivate, "NPC.isFriendly should be private");

            var interactMethod = npcType.GetMethod("Interact");
            Assert.IsTrue(interactMethod.IsPublic, "NPC.Interact should be public");
        }

        #endregion

        #endregion
    }


    public class TestUtils
    {
        internal static void AssertMultilineEqual(string expected, string actual, string message = null)
        {
            string normExpected = expected.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            string normActual = actual.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            if (string.IsNullOrEmpty(message))
            {
                message = $"Expected output:\n{normExpected}\n----\nActual output:\n{normActual}";
            }
            Assert.AreEqual(normExpected, normActual, message);
        }
    }
}
