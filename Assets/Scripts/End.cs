using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    // final grade text
    public Text grade;
    // response to grade text
    public Text response;

    // possible ending animal 
    [Header("Amphibian Sprites")]
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    [Header("Bird Sprites")]
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;

    [Header("Mammal Sprites")]
    public Sprite sprite11;
    public Sprite sprite12;
    public Sprite sprite13;
    public Sprite sprite14;
    public Sprite sprite15;

    [Header("Reptiles Sprites")]
    public Sprite sprite16;
    public Sprite sprite17;
    public Sprite sprite18;
    public Sprite sprite19;
    public Sprite sprite20;

    [Header("Fish Sprites")]
    public Sprite sprite21;
    public Sprite sprite22;
    public Sprite sprite23;
    public Sprite sprite24;
    public Sprite sprite25;

    // sprite renderer of object that displays
    // most matched animal
    public SpriteRenderer speciesSR;

    // most matched species name text
    public Text speciesNameText;
    // most matched species fun fact text
    public Text funfactText;

    CurrentGradeTracker finalGrade;

    private void Start()
    {

        finalGrade = GameObject.Find("Current Grade").GetComponent<CurrentGradeTracker>();

        // figure out final grade
        FindScore(finalGrade.currentGrade);

        // get the species with the higest matches
        DisplaySpecies(SpeciesTracker.mostSpecies);

    }
    // Update is called once per frame
    void Update()
    {
        // restart the game when the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Gameplay");
        }
        
    }

    // determine final grade
    void FindScore(string finalGrade)
    {
        if (finalGrade == "B")
        {
            grade.text = "B";
            response.text = "Keep at it!";

        }
        else if (finalGrade == "B+")
        {
            grade.text = "B+";
            response.text = "Good!";

        }
        else if (finalGrade == "A")
        {
            grade.text = "A";
            response.text = "Amazing!";

        }
        else if (finalGrade == "A+")
        {
            grade.text = "A+";
            response.text = "You knocked my socks off!";

        }

    }

    // display most matched species
    void DisplaySpecies(int type)
    {
        // AMPHIBIANS 
        if (type == 0)
        {
            speciesSR.sprite = sprite1;
            speciesNameText.text = "American Bullfrog";
            funfactText.text = "Produced sound is very loud and it can be heard over half of a mile away. Males vocalize during the mating season.";

        }
        else if (type == 1)
        {
            speciesSR.sprite = sprite2;
            speciesNameText.text = "Eastern Spotted Newt";
            funfactText.text = "It is one of only 7 species of newt in North America, out of only 87 species worldwide.";
        }
        else if (type == 2)
        {
            speciesSR.sprite = sprite3;
            speciesNameText.text = "Mexican Axolotl";
            funfactText.text = "Axolotls have long fascinated scientists for their ability to regenerate " +
                "lost body parts and for their rare trait of neoteny, which means they retain larval features throughout life.";
        }
        else if (type == 3)
        {
            speciesSR.sprite = sprite4;
            speciesNameText.text = "Spotted Salamander";
            funfactText.text = "Like many other salamanders, they secrete a noxious, milky toxin from glands " +
                "on their backs and tails to dissuade predators.";
        }
        else if (type == 4)
        {
            speciesSR.sprite = sprite5;
            speciesNameText.text = "Tree Frog";
            funfactText.text = "Tree frogs are found on every continent except Antarctica, but " +
                "they’re most diverse in the tropics of the western hemisphere.";
        }

        // BIRDS 
        else if (type == 5)
        {
            speciesSR.sprite = sprite6;
            speciesNameText.text = "Emperor Penguin";
            funfactText.text = "Emperors are the largest of all penguins, an average bird stands some 45 inches tall.";
        }
        else if (type == 6)
        {
            speciesSR.sprite = sprite7;
            speciesNameText.text = "Flamingo";
            funfactText.text = "They are able to 'run' on water, thanks to their webbed feet, to gain speed before lifting up into the sky. ";
        }
        else if (type == 7)
        {
            speciesSR.sprite = sprite8;
            speciesNameText.text = "Macaw";
            funfactText.text = "Macaws have been known to use items as tools, and they like to play with interesting objects they find.";
        }
        else if (type == 8)
        {
            speciesSR.sprite = sprite9;
            speciesNameText.text = "Ostrich";
            funfactText.text = "Ostriches can sprint in short bursts up to 43 miles per hour," +
                " and they can maintain a steady speed of 31 miles per hour.";
        }
        else if (type == 9)
        {
            speciesSR.sprite = sprite10;
            speciesNameText.text = "Snowy Owl";
            funfactText.text = "Unlike most owls, Snowy Owls are diurnal, extremely so. " +
                "They’ll hunt at all hours during the continuous daylight of an Arctic summer. ";
        }

        // MAMMALS
        else if (type == 10)
        {
            speciesSR.sprite = sprite11;
            speciesNameText.text = "Cat";
            funfactText.text = "Cats only use their meows to talk to humans, not each other. " +
                "The only time they meow to communicate with other felines is when they are kittens to signal to their mother.";
        }
        else if (type == 11)
        {
            speciesSR.sprite = sprite12;
            speciesNameText.text = "Fruit Bat";
            funfactText.text = "The overall wing length of the Fruit Bat can be more than five feet. " +
                "These bats have large eyes and they also have excellent vision.";
        }
        else if (type == 12)
        {
            speciesSR.sprite = sprite13;
            speciesNameText.text = "Human";
            funfactText.text = "When listening to music, a human's heartbeat will sync with the rhythm. Also, Humans are the only species known to blush.";
        }
        else if (type == 13)
        {
            speciesSR.sprite = sprite14;
            speciesNameText.text = "Narwhal";
            funfactText.text = "These legendary animals have two teeth. In males, the more prominent " +
                "tooth grows into a swordlike, spiral tusk up to 8.8 feet long.";
        }
        else if (type == 14)
        {
            speciesSR.sprite = sprite15;
            speciesNameText.text = "Platypus";
            funfactText.text = "Males have sharp stingers on the heels of their rear feet and can use them to deliver a strong toxic blow to any foe. " +
                "It is one of only two mammals that lay eggs.";
        }

        // REPTILES
        else if (type == 15)
        {
            speciesSR.sprite = sprite16;
            speciesNameText.text = "Alligator";
            funfactText.text = "An average male American alligator is 10 to 15 feet long. Half of its length is its massive, strong tail.";
        }
        else if (type == 16)
        {
            speciesSR.sprite = sprite17;
            speciesNameText.text = "Chameleon";
            funfactText.text = "Chameleans don't really change color to match their surroundings, and they cannot change to any and all colors.";
        }
        else if (type == 17)
        {
            speciesSR.sprite = sprite18;
            speciesNameText.text = "Corn Snake";
            funfactText.text = "Corn snakes are constrictors, wrapping themselves around prey to squeeze and subdue it before swallowing it whole.";
        }
        else if (type == 18)
        {
            speciesSR.sprite = sprite19;
            speciesNameText.text = "Iguana";
            funfactText.text = "Iguanas can detach their tails if caught and will grow another without permanent damage.";
        }
        else if (type == 19)
        {
            speciesSR.sprite = sprite20;
            speciesNameText.text = "Sea Turtle";
            funfactText.text = "Sea turtles are one of the Earth's most ancient creatures. The seven species " +
                "that can be found today have been around for 110  million years, since the time of the dinosaurs.";
        }

        // FISH
        else if (type == 20)
        {
            speciesSR.sprite = sprite21;
            speciesNameText.text = "Clownfish";
            funfactText.text = "Surprisingly, all clownfish are born male. They have the ability " +
                "to switch their gender, but will do so only to become the dominant female of a group. The change is irreversible.";
        }
        else if (type == 21)
        {
            speciesSR.sprite = sprite22;
            speciesNameText.text = "Manta Ray";
            funfactText.text = "Manta Rays are giant animals. Their size can reach up to 9 meters and can weight up to 2 tons.";
        }
        else if (type == 22)
        {
            speciesSR.sprite = sprite23;
            speciesNameText.text = "Moray Eel";
            funfactText.text = "Moray eels secrete a mucus over their smooth skins in greater quantities than other eels, " +
                "allowing them to swim fast around the reef without fear of abrasion.";
        }
        else if (type == 23)
        {
            speciesSR.sprite = sprite24;
            speciesNameText.text = "Stonefish";
            funfactText.text = "The stonefish, which reaches an average length of 30 to 40 centimeters and up to 5 lbs in weight, " +
                "is the most venomous fish in the world having venomous sacs on each one of its 13 spines.";
        }
        else if (type == 24)
        {
            speciesSR.sprite = sprite25;
            speciesNameText.text = "Whale Shark";
            funfactText.text = "Although the largest fish in the world, whale sharks are docile and sometimes allow swimmers to hitch a ride.";
        }

    }
}
